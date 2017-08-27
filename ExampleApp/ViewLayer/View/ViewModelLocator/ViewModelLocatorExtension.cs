namespace View.ViewModelLocator
{
	using System;
	using System.Windows.Markup;
	using IoC;

	public class ViewModelLocatorExtension : MarkupExtension
	{
		[ConstructorArgument("ViewModelType")]
		public Type ViewModelType { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var resolveMethod = typeof(ServiceLocator).GetMethod("Resolve").MakeGenericMethod(ViewModelType);
			return resolveMethod.Invoke(ServiceLocator.Instance, new object[] { });
		}
	}
}