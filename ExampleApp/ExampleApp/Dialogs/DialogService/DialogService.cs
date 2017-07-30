namespace MvvmDialogs
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using CommonUtilities.ArgumentMust;
    using Dialogs.Dialog;
    using Dialogs.DialogFactory;
    using Dialogs.DialogViewModel;
    using Dialogs.MicrosoftDialogs.FolderBrowserDialog;
    using Dialogs.MicrosoftDialogs.OpenFileDialog;
    using Dialogs.MicrosoftDialogs.SaveFileDialog;
    using DialogTypeLocators;
    using FrameworkDialogs;
    using MessageBox = System.Windows.MessageBox;

    public class DialogService : IDialogService
    {
        private readonly IDialogFactory _dialogFactory;
        private readonly IDialogTypeLocator _dialogTypeLocator;

        public DialogService(IDialogFactory dialogFactory, IDialogTypeLocator dialogTypeLocator)
        {
            ArgumentMust.NotBeNull(() => dialogFactory);
            ArgumentMust.NotBeNull(() => dialogTypeLocator);

            _dialogFactory = dialogFactory;
            _dialogTypeLocator = dialogTypeLocator;
        }

        public void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
            where T : Window
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            Show(ownerViewModel, viewModel, typeof(T));
        }
        
        public void ShowCustom<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
            where T : IDialogView
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            Show(ownerViewModel, viewModel, typeof(T));
        }
        
        public void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            var dialogType = _dialogTypeLocator.Locate(viewModel);
            Show(ownerViewModel, viewModel, dialogType);
        }
        
        public bool? ShowDialog<T>(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel)
            where T : Window
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }
        
        public bool? ShowCustomDialog<T>(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel)
            where T : IDialogView
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }
        
        public bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => viewModel);

            var dialogType = _dialogTypeLocator.Locate(viewModel);
            return ShowDialog(ownerViewModel, viewModel, dialogType);
        }
        
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string messageBoxText,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);

            return MessageBox.Show(
                FindOwnerWindow(ownerViewModel),
                messageBoxText,
                caption,
                button,
                icon,
                defaultResult);
        }
        
        public bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogConfig config)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => config);

            var dialog = new OpenFileDialogWrapper(config);
            return dialog.ShowDialog(FindOwnerWindow(ownerViewModel));
        }
        
        public bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogConfig config)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => config);
            
            var dialog = new SaveFileDialogWrapper(config);
            return dialog.ShowDialog(FindOwnerWindow(ownerViewModel));
        }
        
        public bool? ShowFolderBrowserDialog(
            INotifyPropertyChanged ownerViewModel,
            FolderBrowserDialogConfig config)
        {
            ArgumentMust.NotBeNull(() => ownerViewModel);
            ArgumentMust.NotBeNull(() => config);
            
            using (var dialog = new FolderBrowserDialogWrapper(config))
            {
                var result = dialog.ShowDialog(new Win32Window(FindOwnerWindow(ownerViewModel)));
                return result == DialogResult.OK;
            }
        }

        private void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel, Type dialogType)
        {
            var dialogView = CreateDialog(dialogType, ownerViewModel, viewModel);
            dialogView.Show();
        }

        private bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel, Type dialogType)
        {
            var dialogView = CreateDialog(dialogType, ownerViewModel, viewModel);

            var handler = RegisterDialogResult(dialogView, viewModel);
            dialogView.ShowDialog();
            UnregisterDialogResult(viewModel, handler);

            return viewModel.DialogResult;
        }

        private IDialogView CreateDialog(Type dialogType, INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            var dialog = _dialogFactory.Create(dialogType);
            dialog.Owner = FindOwnerWindow(ownerViewModel);
            dialog.DataContext = viewModel;

            return dialog;
        }

        private static PropertyChangedEventHandler RegisterDialogResult(IDialogView dialogView, IDialogViewModel viewModel)
        {
            PropertyChangedEventHandler handler = (sender, e) =>
            {
                if (e.PropertyName == DialogResultPropertyName && dialogView.DialogResult != viewModel.DialogResult)
                {
                    dialogView.DialogResult = viewModel.DialogResult;
                }
            };

            viewModel.PropertyChanged += handler;

            return handler;
        }

        private static void UnregisterDialogResult(IDialogViewModel viewModel, PropertyChangedEventHandler handler)
        {
            viewModel.PropertyChanged -= handler;
        }
        
        private static Window FindOwnerWindow(INotifyPropertyChanged viewModel)
        {
            var view = DialogServiceViews.Views.SingleOrDefault(
                registeredView =>
                    registeredView.Source.IsLoaded &&
                    ReferenceEquals(registeredView.DataContext, viewModel));

            if (view == null)
            {
                var message =
                    $"View model of type '{viewModel.GetType()}' is not present as data context on any registered view." +
                    "Please register the view by setting DialogServiceViews.IsRegistered=\"True\" in your XAML.";

                throw new DialogViewNotRegisteredException(message);
            }

            // Get owner window
            Window owner = view.GetOwner();
            if (owner == null)
                throw new InvalidOperationException($"View of type '{view.GetType()}' is not registered.");

            return owner;
        }
    }
}