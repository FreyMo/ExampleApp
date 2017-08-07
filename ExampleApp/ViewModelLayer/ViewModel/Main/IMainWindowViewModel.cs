namespace ViewModel.Main
{
	using System.Collections.Generic;
	using System.Globalization;

	public interface IMainWindowViewModel
	{
		IEnumerable<CultureInfo> Cultures { get; }

		TestEnum SelectedNumber { get; set; }

		CultureInfo SelectedCulture { get; set; }
	}
}