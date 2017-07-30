namespace ViewLayer.Translation.MarkupExtensions
{
	using System;
	using System.Windows.Data;
	using System.Windows.Markup;
	using global::Translation.TranslationAdapter;

	public class TranslatableTextExtension : MarkupExtension
	{
		private readonly string _key;
		
		public TranslatableTextExtension(string key)
		{
			_key = key;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var binding = new Binding(nameof(TranslationAdapter.Value))
			{
				Source = new TranslationAdapter(_key)
			};
			
			return binding.ProvideValue(serviceProvider);
		}
	}
}
