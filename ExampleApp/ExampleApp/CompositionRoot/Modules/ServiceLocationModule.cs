namespace ExampleApp.CompositionRoot.Modules
{
	using Ninject;
	using Ninject.Modules;
	using ServiceLocation;
	using ServiceLocation.ViewModelLocator;

	internal class ServiceLocationModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Get<Creator>();
			Kernel.Bind<IViewModelLocator>().To<ViewModelLocator>().InSingletonScope();
		}
	}
}