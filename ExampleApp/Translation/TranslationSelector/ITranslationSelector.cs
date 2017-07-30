namespace Translation.TranslationSelector
{
	using System.Globalization;

	public interface ITranslationSelector
	{
		CultureInfo CurrentUiCulture { get; set; }
	}
}