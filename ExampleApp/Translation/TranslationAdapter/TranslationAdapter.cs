namespace Translation.TranslationAdapter
{
	using Common.ArgumentMust;
	using Common.Notification;
	using IoC;
	using Messenger.Messenger;
	using TranslationMessenger;
	using Translator;

	public class TranslationAdapter : BindableBase, ISubscriber<CultureChangedMessage>
	{
		private readonly string _key;
		private readonly ITranslator _translator;
		
		public TranslationAdapter(string key) : this(
			key,
			ServiceLocator.Instance.Resolve<ITranslator>(),
			ServiceLocator.Instance.Resolve<ITranslationMessenger>())
		{
		}

		public TranslationAdapter(string key,
			ITranslator translator,
			ITranslationMessenger translationMessenger)
		{
			ArgumentMust.NotBeNull(() => key);
			ArgumentMust.NotBeNull(() => translator);
			ArgumentMust.NotBeNull(() => translationMessenger);

			_key = key;
			_translator = translator;

			translationMessenger.SubscribeTo(this);
		}
		
		public string Value => _translator.Translate(_key);

		public void OnMessageReceived(CultureChangedMessage message)
		{
			OnPropertyChanged(nameof(Value));
		}
	}
}