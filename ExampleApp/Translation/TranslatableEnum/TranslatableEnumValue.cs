﻿namespace Translation.TranslatableEnum
{
	using System.Reflection;
	using Common.ArgumentMust;
	using Common.Attributes;
	using Common.Extensions;
	using Common.Notification;
	using Translator;

	public class TranslatableEnumValue : BindableBase
	{
		private readonly string _key;
		private readonly ITranslator _translator;

		public TranslatableEnumValue(object enumEnumValue, ITranslator translator)
		{
			ArgumentMust.NotBeNull(() => translator);

			EnumValue = enumEnumValue;
			_translator = translator;

			var attribute = GetDescriptionKeyAttribute(enumEnumValue);
			if (attribute != null)
			{
				_key = attribute.Key;
			}
		}

		public string TranslatedName => _translator.Translate(_key);

		public object EnumValue { get; }

		private static DescriptionKeyAttribute GetDescriptionKeyAttribute(object enumValue)
		{
			var field = enumValue.GetType().GetField(enumValue.ToString());

			return field.GetCustomAttribute(typeof(DescriptionKeyAttribute)).As<DescriptionKeyAttribute>();
		}
	}
}