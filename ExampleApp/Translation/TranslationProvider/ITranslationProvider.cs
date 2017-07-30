namespace Translation.TranslationProvider
{
	public interface ITranslationProvider
	{
		object Translate(string key);
	}
}