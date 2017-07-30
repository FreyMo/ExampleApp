namespace Dialogs.MicrosoftDialogs.SaveFileDialog
{
	using System;
	using Microsoft.Win32;

	/// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>.
    /// </summary>
    internal sealed class SaveFileDialogWrapper
    {
        private readonly SaveFileDialogConfig config;
        private readonly SaveFileDialog saveFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="config">The config for the save file dialogView.</param>
        public SaveFileDialogWrapper(SaveFileDialogConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;

            saveFileDialog = new SaveFileDialog
            {
                AddExtension = config.AddExtension,
                CheckFileExists = config.CheckFileExists,
                CheckPathExists = config.CheckPathExists,
                CreatePrompt = config.CreatePrompt,
                DefaultExt = config.DefaultExt,
                FileName = config.FileName,
                Filter = config.Filter,
                InitialDirectory = config.InitialDirectory,
                OverwritePrompt = config.OverwritePrompt,
                Title = config.Title
            };
        }

        /// <summary>
        /// Runs a common dialogView box with the specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialogView.
        /// </param>
        /// <returns>
        /// If the user clicks the OK button of the dialogView that is displayed, true is returned;
        /// otherwise false.
        /// </returns>
        public bool? ShowDialog(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            bool? result = saveFileDialog.ShowDialog(owner);

            // Update config
            config.FileName = saveFileDialog.FileName;
            config.FileNames = saveFileDialog.FileNames;

            return result;
        }
    }
}