namespace Translation.TranslationManager
{
	using System.Globalization;

	public interface ITranslationManager
	{
		CultureInfo CurrentUiCulture { get; set; }
	}
}