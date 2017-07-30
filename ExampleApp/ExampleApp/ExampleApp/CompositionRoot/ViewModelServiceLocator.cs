namespace ExampleApp.CompositionRoot
{
	using Modules;
	using Ninject;
	using ViewModelLayer.Main;

	public class ViewModelServiceLocator
	{
		private readonly IKernel _kernel = new StandardKernel();

		public ViewModelServiceLocator()
		{
			_kernel.Load<ServiceLocationModule>();
			_kernel.Load<TranslationModule>();
			_kernel.Load<MainModule>();
		}

		public IMainWindowViewModel MainWindowViewModel => _kernel.Get<IMainWindowViewModel>();
	}
}