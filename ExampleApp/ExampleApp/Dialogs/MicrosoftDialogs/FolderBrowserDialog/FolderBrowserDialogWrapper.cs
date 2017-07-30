namespace Dialogs.MicrosoftDialogs.FolderBrowserDialog
{
	using System;
	using System.Windows.Forms;
	using CommonUtilities.ArgumentMust;

	internal sealed class FolderBrowserDialogWrapper : IDisposable
	{
		private readonly FolderBrowserDialog _folderBrowserDialog;
		private readonly FolderBrowserDialogConfig _config;

		public FolderBrowserDialogWrapper(FolderBrowserDialogConfig config)
		{
			ArgumentMust.NotBeNull(() => config);

			_config = config;

			_folderBrowserDialog = new FolderBrowserDialog
			{
				Description = config.Description,
				SelectedPath = config.SelectedPath,
				ShowNewFolderButton = config.ShowNewFolderButton
			};
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			ArgumentMust.NotBeNull(() => owner);

			var result = _folderBrowserDialog.ShowDialog(owner);
			
			_config.SelectedPath = _folderBrowserDialog.SelectedPath;

			return result;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				_folderBrowserDialog?.Dispose();
			}
		}
	}
}