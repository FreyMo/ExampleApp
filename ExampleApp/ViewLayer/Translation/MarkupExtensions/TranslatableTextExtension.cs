namespace ViewLayer.Translation.MarkupExtensions
{
	using System;
	using System.Windows.Data;
	using System.Windows.Markup;
	using global::Translation.TranslationAdapter;

	public class TranslatableTextExtension : MarkupExtension
	{
		public TranslatableTextExtension()
		{
		}

		public TranslatableTextExtension(string key)
		{
			Key = key;
		}
		
		[ConstructorArgument("key")]
		public string Key { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var binding = new Binding(nameof(TranslationAdapter.Value))
			{
				Source = new TranslationAdapter(Key)
			};
			
			return binding.ProvideValue(serviceProvider);
		}
	}
}
