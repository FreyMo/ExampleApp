namespace Dialogs.DialogViewModel
{
    using System.ComponentModel;

    public interface IDialogViewModel : INotifyPropertyChanged
    {
        bool? DialogResult { get; }
    }
}