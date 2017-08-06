namespace ExampleApp.CompositionRoot
{
	using Modules;
	using Ninject;

	public class CompositionRoot
	{
		private readonly IKernel _kernel = new StandardKernel();

		public CompositionRoot()
		{
			_kernel.Load<ServiceLocationModule>();
			_kernel.Load<TranslationModule>();
			_kernel.Load<MainModule>();
			_kernel.Load<MatLabModule>();
		}
	}
}