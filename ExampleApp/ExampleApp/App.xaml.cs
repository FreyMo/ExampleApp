namespace ExampleApp
{
	using System.Windows;
	using IoCImpl;
	using Ninject;

	public partial class App : Application
	{
		private readonly BootStrapper.BootStrapper _bootStrapper = new BootStrapper.BootStrapper(new NinjectAdapter(new StandardKernel()));
	}
}