namespace ViewLayer.Translation.MarkupExtensions
{
	using System;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Markup;
	using System.Windows.Threading;
	using Common.ArgumentMust;
	using Common.Extensions;
	using global::Translation.TranslatableEnum;

	public class TranslatableEnumsExtension : MarkupExtension
	{
		private readonly Type _enumType;

		public TranslatableEnumsExtension(Type enumType)
		{
			ArgumentMust.BeEnum(() => enumType);

			_enumType = enumType;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			SetSelectedValuePath(serviceProvider);

			var binding = new Binding(nameof(TranslatableEnumAdapter.Values))
			{
				Source = new TranslatableEnumAdapter(_enumType)
			};

			return binding.ProvideValue(serviceProvider);
		}

		private static void SetSelectedValuePath(IServiceProvider serviceProvider)
		{
			var target = serviceProvider.GetService(typeof(IProvideValueTarget)).As<IProvideValueTarget>();
			if (target?.TargetObject is ComboBox)
			{
				// TODO: update selected text on language change.
				target.TargetObject.Cast<ComboBox>().Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));

				target.TargetObject.Cast<ComboBox>().DisplayMemberPath = nameof(TranslatableEnumValue.TranslatedName);
				target.TargetObject.Cast<ComboBox>().SelectedValuePath = nameof(TranslatableEnumValue.Value);
			}
		}
	}
}