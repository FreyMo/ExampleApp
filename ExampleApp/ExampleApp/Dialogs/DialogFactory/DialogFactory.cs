namespace Dialogs.DialogFactory
{
	using System;
	using System.Windows;
	using CommonUtilities.ArgumentMust;
	using CommonUtilities.Extensions;
	using Dialog;

	public class DialogFactory : IDialogFactory
	{
		public IDialogView Create(Type dialogType)
		{
			ArgumentMust.NotBeNull(() => dialogType);

			var instance = Activator.CreateInstance(dialogType);

			if (instance.Is<IDialogView>())
			{
				return instance.As<IDialogView>();
			}

			if (instance.Is<Window>())
			{
				return new DialogView(instance.As<Window>());
			}

			throw new ArgumentException($"The specified parameter is not of the required types {typeof(Window)} or {typeof(IDialogView)}.", nameof(dialogType));
		}
	}
}