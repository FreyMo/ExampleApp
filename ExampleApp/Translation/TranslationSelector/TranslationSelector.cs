namespace Translation.TranslationManager
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Threading;
	using Common.ArgumentMust;
	using TranslationMessenger;

	public class TranslationManager : ITranslationManager
	{
		private readonly ITranslationMessenger _messenger;

		public TranslationManager(ITranslationMessenger messenger)
		{
			ArgumentMust.NotBeNull(() => messenger);

			_messenger = messenger;
		}

		public CultureInfo CurrentUiCulture
		{
			get => Thread.CurrentThread.CurrentUICulture;
			set
			{
				if (!value.Equals(Thread.CurrentThread.CurrentUICulture))
				{
					Thread.CurrentThread.CurrentUICulture = value;
					_messenger.Send(new CultureChangedMessage());
				}
			}
		}

		public static IEnumerable<CultureInfo> Cultures
		{
			get
			{
				yield return new CultureInfo("de-DE");
				yield return new CultureInfo("fr-FR");
				yield return new CultureInfo("en-US");
			}
		}
	}
}