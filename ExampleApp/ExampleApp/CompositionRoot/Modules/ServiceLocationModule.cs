namespace ExampleApp.CompositionRoot.Modules
{
	using Ninject;
	using Ninject.Modules;
	using ServiceLocation;

	internal class ServiceLocationModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Get<Creator>();
		}
	}
}