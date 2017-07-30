namespace Dialogs.MicrosoftDialogs.SaveFileDialog
{
	using System.Windows.Forms;

	/// <summary>
    /// Settings for <see cref="SaveFileDialog"/>.
    /// </summary>
    public class SaveFileDialogConfig : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box prompts the user for permission
        /// to create a file if the user specifies a file that does not exist.
        /// </summary>
        public bool CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Save As</b> dialogView box displays a
        /// warning if the user specifies a file name that already exists.
        /// </summary>
        public bool OverwritePrompt { get; set; }
    }
}