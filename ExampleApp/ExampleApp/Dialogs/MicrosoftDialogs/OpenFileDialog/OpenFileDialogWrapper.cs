namespace Dialogs.MicrosoftDialogs.OpenFileDialog
{
	using System;
	using Microsoft.Win32;

	/// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialogWrapper
    {
        private readonly OpenFileDialogConfig config;
        private readonly OpenFileDialog openFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="config">The config for the open file dialogView.</param>
        public OpenFileDialogWrapper(OpenFileDialogConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;

            openFileDialog = new OpenFileDialog
            {
                AddExtension = config.AddExtension,
                CheckFileExists = config.CheckFileExists,
                CheckPathExists = config.CheckPathExists,
                DefaultExt = config.DefaultExt,
                FileName = config.FileName,
                Filter = config.Filter,
                InitialDirectory = config.InitialDirectory,
                Multiselect = config.Multiselect,
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

            bool? result = openFileDialog.ShowDialog(owner);

            // Update config
            config.FileName = openFileDialog.FileName;
            config.FileNames = openFileDialog.FileNames;

            return result;
        }
    }
}