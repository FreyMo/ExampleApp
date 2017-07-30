namespace ViewModelLayerImpl.Main
{
	using System.Collections.Generic;
	using System.Globalization;
	using Common.ArgumentMust;
	using Translation.TranslationSelector;
	using ViewModelLayer.Main;

	public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
	{
		private readonly ITranslationSelector _translationSelector;

		private CultureInfo _selectedCultureInfo;

		private TestEnum _selectedNumber;

		public MainWindowViewModel(ITranslationSelector translationSelector)
		{
			ArgumentMust.NotBeNull(() => translationSelector);

			_translationSelector = translationSelector;
			_selectedCultureInfo = _translationSelector.CurrentUiCulture;
		}

		public IEnumerable<CultureInfo> Cultures => TranslationSelector.Cultures;

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
					_translationSelector.CurrentUiCulture = value;
				}
			}
		}
	}
}