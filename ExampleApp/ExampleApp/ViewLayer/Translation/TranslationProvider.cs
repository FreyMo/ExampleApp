namespace ViewLayer.Translation
{
	using System.Resources;
	using global::Translation.TranslationProvider;

	public class TranslationProvider : ITranslationProvider
	{
		private readonly ResourceManager _resourceManager = Resources.Resources.ResourceManager;

		public object Translate(string key)
		{
			var translatedValue = _resourceManager.GetString(key);

			return translatedValue ?? $"Key not found: {key}";
		}
	}
}