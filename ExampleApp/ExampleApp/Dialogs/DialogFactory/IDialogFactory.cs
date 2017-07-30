namespace Dialogs.DialogFactory
{
	using System;
	using Dialog;

	public interface IDialogFactory
	{
		IDialogView Create(Type dialogType);
	}
}