namespace ExampleApp.CompositionRoot.Modules
{
	using Common.ArgumentMust;
	using Ninject.Modules;
	using ViewModelLayer.Main;
	using ViewModelLayerImpl.Main;

	internal class MainModule : NinjectModule
    {
        public override void Load()
        {
            ArgumentMust.NotBeNull(() => Kernel);

            Kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>().InSingletonScope();
        }
    }
}