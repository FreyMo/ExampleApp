namespace ExampleApp.CompositionRoot.Modules
{
	using MatLabImpl;
	using Ninject.Modules;

	internal class MatLabModule : NinjectModule
	{
		public override void Load()
		{
			var temp = new MatLabBase();
			var res = MatLabBase.GetFuncResult();
		}
	}
}