namespace ExampleApp.CompositionRoot.Modules
{
	using Ninject.Modules;
	using ViewModelLayer.Main;
	using ViewModelLayerImpl.Main;

	internal class MainModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>().InSingletonScope();
		}
	}
}