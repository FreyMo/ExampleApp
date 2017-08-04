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
	using Translator;

	public class TranslatableEnumAdapter : BindableBase, ISubscriber<CultureChangedMessage>
	{
		private IList<TranslatableEnumValue> _translatableEnumValues;

		public TranslatableEnumAdapter(Type enumType) : this(
			enumType,
			ServiceLocator.Instance.Get<ITranslator>(),
			ServiceLocator.Instance.Get<ITranslationMessenger>())
		{
		}

		public TranslatableEnumAdapter(
			Type enumType,
			ITranslator translator,
			ITranslationMessenger translationMessenger)
		{
			ArgumentMust.BeEnum(() => enumType);
			ArgumentMust.NotBeNull(() => translator);
			ArgumentMust.NotBeNull(() => translationMessenger);

			translationMessenger.SubscribeTo(this);

			PopulateEnumValues(enumType, translator);
		}

		public object Values => _translatableEnumValues.ToList();

		public void OnMessageReceived(CultureChangedMessage message)
		{
			OnPropertyChanged(nameof(Values));
		}

		private void PopulateEnumValues(Type enumType, ITranslator translator)
		{
			_translatableEnumValues = (from object enumValue
			                           in Enum.GetValues(enumType)
			                           select new TranslatableEnumValue(enumValue, translator)).ToList();
		}
	}
}