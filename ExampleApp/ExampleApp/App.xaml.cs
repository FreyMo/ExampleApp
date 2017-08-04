namespace ExampleApp
{
	using System.Windows;

	public partial class App : Application
	{
		private readonly CompositionRoot.CompositionRoot _compositionRoot = new CompositionRoot.CompositionRoot();

		public App()
		{
		}
	}
}