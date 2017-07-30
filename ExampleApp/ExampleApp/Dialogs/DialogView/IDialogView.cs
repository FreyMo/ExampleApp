namespace Dialogs.Dialog
{
	using System.Windows.Controls;

	public interface IDialogView
	{
		object DataContext { get; set; }

		bool? DialogResult { get; set; }

		ContentControl Owner { get; set; }

		bool? ShowDialog();

		void Show();
	}
}