namespace ViewLayer.Translation
{
	using System.Resources;
	using global::Translation.Translator;

	public class Translator : ITranslator
	{
		private readonly ResourceManager _resourceManager = Resources.Resources.ResourceManager;

		public string Translate(string key)
		{
			var translatedValue = _resourceManager.GetString(key);

			return translatedValue ?? $"Key not found: {key}";
		}
	}
}