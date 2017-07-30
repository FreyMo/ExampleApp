namespace Dialogs.MicrosoftDialogs.OpenFileDialog
{
	using System.Windows.Forms;

	/// <summary>
    /// Settings for <see cref="OpenFileDialog"/>.
    /// </summary>
    public class OpenFileDialogConfig : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialogView box allows multiple files to be
        /// selected.
        /// </summary>
        public bool Multiselect { get; set; }
    }
}