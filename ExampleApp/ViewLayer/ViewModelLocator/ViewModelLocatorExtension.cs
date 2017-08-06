namespace ViewLayer.ViewModelLocator
{
	using System;
	using System.Windows.Markup;

	public class ViewModelLocatorExtension : MarkupExtension
	{
		[ConstructorArgument("ViewModelType")]
		public Type ViewModelType { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return ServiceLocation.ServiceLocator.Instance.Get(ViewModelType);
		}
	}
}