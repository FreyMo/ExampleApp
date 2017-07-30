namespace ViewModelLayerImpl.Main
{
	using System.Collections.Generic;
	using System.Globalization;
	using Common.ArgumentMust;
	using Translation.TranslationManager;
	using ViewModelLayer.Main;

	public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
	{
		private readonly ITranslationManager _translationManager;

		private CultureInfo _selectedCultureInfo;

		private TestEnum _selectedNumber;

		public MainWindowViewModel(ITranslationManager translationManager)
		{
			ArgumentMust.NotBeNull(() => translationManager);

			_translationManager = translationManager;
			_selectedCultureInfo = _translationManager.CurrentUiCulture;
		}

		public IEnumerable<CultureInfo> Cultures => TranslationManager.Cultures;

		public TestEnum SelectedNumber
		{
			get => _selectedNumber;

			set
			{
				if (!_selectedNumber.Equals(value))
				{
					_selectedNumber = value;
					OnPropertyChanged();
				}
			}
		}

		public CultureInfo SelectedCulture
		{
			get => _selectedCultureInfo;

			set
			{
				if (!_selectedCultureInfo.Equals(value))
				{
					_selectedCultureInfo = value;
					OnPropertyChanged();
					_translationManager.CurrentUiCulture = value;
				}
			}
		}
	}
}