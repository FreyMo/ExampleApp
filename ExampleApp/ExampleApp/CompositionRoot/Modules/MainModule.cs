namespace ExampleApp.CompositionRoot.Modules
{
	using Ninject.Modules;
	using ViewModel.Main;
	using ViewModelImpl.Main;

	internal class MainModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<IMainWindowViewModel>().To<MainWindowViewModel>().InSingletonScope();
		}
	}
}