namespace MvvmDialogs
{
    using System;
    using Dialogs.Dialog;

    public class DialogViewNotRegisteredException : Exception
    {
        public DialogViewNotRegisteredException(IDialogView dialogView)
            : base($"The following dialog view has not been registered: {dialogView.GetType()}")
        {
        }
    }
}