namespace Translation.TranslationAdapter
{
	using Common.ArgumentMust;
	using Common.Notification;
	using Messenger.Messenger;
	using ServiceLocation;
	using TranslationMessenger;
	using TranslationProvider;

	public class TranslationAdapter : BindableBase, ISubscriber<CultureChangedMessage>
	{
		private readonly string _key;
		private readonly ITranslationProvider _translationProvider;
		
		public TranslationAdapter(string key) : this(
			key,
			ServiceLocator.Instance.Get<ITranslationProvider>(),
			ServiceLocator.Instance.Get<ITranslationMessenger>())
		{
		}

		public TranslationAdapter(string key,
			ITranslationProvider translationProvider,
			ITranslationMessenger translationMessenger)
		{
			ArgumentMust.NotBeNull(() => key);
			ArgumentMust.NotBeNull(() => translationProvider);
			ArgumentMust.NotBeNull(() => translationMessenger);

			_key = key;
			_translationProvider = translationProvider;

			translationMessenger.SubscribeTo(this);
		}
		
		public object Value => _translationProvider.Translate(_key);

		public void OnMessageReceived(CultureChangedMessage message)
		{
			OnPropertyChanged(nameof(Value));
		}
	}
}