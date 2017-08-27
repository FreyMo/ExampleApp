namespace ExampleApp
{
	using System.Windows;
	using IoCImpl;
	using Ninject;

	public partial class App : Application
	{
		private readonly CompositionRoot.CompositionRoot _compositionRoot = new CompositionRoot.CompositionRoot(new NinjectAdapter(new StandardKernel()));
	}
}