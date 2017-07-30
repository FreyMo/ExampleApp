namespace Translation.TranslatableEnum
{
	using System.Reflection;
	using Common.ArgumentMust;
	using Common.Attributes;
	using Common.Extensions;
	using Common.Notification;
	using TranslationProvider;

	public class TranslatableEnumValue : BindableBase
	{
		private readonly string _key;
		private readonly ITranslationProvider _translationProvider;

		public TranslatableEnumValue(object enumValue, ITranslationProvider translationProvider)
		{
			ArgumentMust.NotBeNull(() => translationProvider);

			Value = enumValue;
			_translationProvider = translationProvider;

			var attribute = GetDescriptionKeyAttribute(enumValue);
			if (attribute != null)
			{
				_key = attribute.Key;
			}
		}

		public object TranslatedName => _translationProvider.Translate(_key);

		public object Value { get; }

		private static DescriptionKeyAttribute GetDescriptionKeyAttribute(object enumValue)
		{
			var field = enumValue.GetType().GetField(enumValue.ToString());

			return field.GetCustomAttribute(typeof(DescriptionKeyAttribute)).As<DescriptionKeyAttribute>();
		}
	}
}