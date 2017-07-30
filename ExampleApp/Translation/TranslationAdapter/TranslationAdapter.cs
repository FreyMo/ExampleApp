namespace Translation.TranslationAdapter
{
	using Common.ArgumentMust;
	using Common.Notification;
	using Messenger.Messenger;
	using ServiceLocation;
	using TranslationMessenger;
	using Translator;

	public class TranslationAdapter : BindableBase, ISubscriber<CultureChangedMessage>
	{
		private readonly string _key;
		private readonly ITranslator _translator;
		
		public TranslationAdapter(string key) : this(
			key,
			ServiceLocator.Instance.Get<ITranslator>(),
			ServiceLocator.Instance.Get<ITranslationMessenger>())
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
		
		public object Value => _translator.Translate(_key);

		public void OnMessageReceived(CultureChangedMessage message)
		{
			OnPropertyChanged(nameof(Value));
		}
	}
}