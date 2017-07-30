namespace Translation.TranslatableEnum
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common.ArgumentMust;
	using Common.Notification;
	using Messenger.Messenger;
	using ServiceLocation;
	using TranslationMessenger;
	using TranslationProvider;

	public class TranslatableEnumAdapter : BindableBase, ISubscriber<CultureChangedMessage>
	{
		private IList<TranslatableEnumValue> _translatableEnumValues;

		public TranslatableEnumAdapter(Type enumType) : this(
			enumType,
			ServiceLocator.Instance.Get<ITranslationProvider>(),
			ServiceLocator.Instance.Get<ITranslationMessenger>())
		{
		}

		public TranslatableEnumAdapter(
			Type enumType,
			ITranslationProvider translationProvider,
			ITranslationMessenger translationMessenger)
		{
			ArgumentMust.BeEnum(() => enumType);
			ArgumentMust.NotBeNull(() => translationProvider);
			ArgumentMust.NotBeNull(() => translationMessenger);

			translationMessenger.SubscribeTo(this);

			PopulateEnumValues(enumType, translationProvider);
		}

		public object Values => _translatableEnumValues.ToList();

		public void OnMessageReceived(CultureChangedMessage message)
		{
			OnPropertyChanged(nameof(Values));
		}

		private void PopulateEnumValues(Type enumType, ITranslationProvider translationProvider)
		{
			_translatableEnumValues = (from object enumValue
				in Enum.GetValues(enumType)
				select new TranslatableEnumValue(enumValue, translationProvider)).ToList();
		}
	}
}