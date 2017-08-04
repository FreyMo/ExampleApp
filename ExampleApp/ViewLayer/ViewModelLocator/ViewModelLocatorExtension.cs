namespace ViewLayer.ViewModelLocator
{
	using System;
	using System.Windows.Markup;
	using Common.ArgumentMust;
	using ServiceLocation;
	using ServiceLocation.ViewModelLocator;

	public class ViewModelLocatorExtension : MarkupExtension
	{
		private readonly IViewModelLocator _viewModelLocator;

		public ViewModelLocatorExtension() :
			this(ServiceLocator.Instance.Get<IViewModelLocator>())
		{
		}

		public ViewModelLocatorExtension(IViewModelLocator viewModelLocator)
		{
			ArgumentMust.NotBeNull(() => viewModelLocator);

			_viewModelLocator = viewModelLocator;
		}

		[ConstructorArgument("ViewModelType")]
		public Type ViewModelType { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _viewModelLocator.Get(ViewModelType);
		}
	}
}