namespace Dialogs.Dialog
{
	using System.Windows;
	using System.Windows.Controls;
	using CommonUtilities.ArgumentMust;

	public class DialogView : IDialogView
	{
		private readonly Window _window;

		public DialogView(Window window)
		{
			ArgumentMust.NotBeNull(() => window);

			_window = window;
		}

		public object DataContext
		{
			get => _window.DataContext;
			set => _window.DataContext = value;
		}

		public bool? DialogResult
		{
			get => _window.DialogResult;
			set => _window.DialogResult = value;
		}

		public ContentControl Owner
		{
			get => _window.Owner;
			set => _window.Owner = (Window)value;
		}

		public bool? ShowDialog()
		{
			return _window.ShowDialog();
		}

		public void Show()
		{
			_window.Show();
		}
	}
}