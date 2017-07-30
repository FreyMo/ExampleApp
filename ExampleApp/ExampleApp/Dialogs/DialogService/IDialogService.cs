namespace MvvmDialogs
{
	using System.ComponentModel;
	using System.Windows;
	using Dialogs.Dialog;
	using Dialogs.DialogViewModel;
	using Dialogs.MicrosoftDialogs.FolderBrowserDialog;
	using Dialogs.MicrosoftDialogs.OpenFileDialog;
	using Dialogs.MicrosoftDialogs.SaveFileDialog;

	public interface IDialogService
	{
		void Show<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
			where T : Window;

		void ShowCustom<T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
			where T : IDialogView;

		void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel);

		bool? ShowDialog<T>(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel)
			where T : Window;

		bool? ShowCustomDialog<T>(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel)
			where T : IDialogView;

		bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IDialogViewModel viewModel);

		MessageBoxResult ShowMessageBox(
			INotifyPropertyChanged ownerViewModel,
			string messageBoxText,
			string caption = "",
			MessageBoxButton button = MessageBoxButton.OK,
			MessageBoxImage icon = MessageBoxImage.None,
			MessageBoxResult defaultResult = MessageBoxResult.None);

		bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogConfig config);

		bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogConfig config);

		bool? ShowFolderBrowserDialog(INotifyPropertyChanged ownerViewModel, FolderBrowserDialogConfig config);
	}
}