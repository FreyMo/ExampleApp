namespace ExampleApp.CompositionRoot.Modules
{
	using Common.ArgumentMust;
	using Ninject;
	using Ninject.Modules;
	using ServiceLocation;

	internal class ServiceLocationModule : NinjectModule
	{
		public override void Load()
		{
			ArgumentMust.NotBeNull(() => Kernel);

			var temp = Kernel.Get<Creator>();
		}
	}
}