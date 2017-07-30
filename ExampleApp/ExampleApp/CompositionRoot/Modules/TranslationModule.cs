namespace ExampleApp.CompositionRoot.Modules
{
	using Common.ArgumentMust;
	using Ninject.Modules;
	using Translation.TranslationManager;
	using Translation.TranslationMessenger;
	using Translation.TranslationProvider;
	using ViewLayer.Translation;

	internal class TranslationModule : NinjectModule
	{
		public override void Load()
		{
			ArgumentMust.NotBeNull(() => Kernel);

			Kernel.Bind<ITranslationManager>().To<TranslationManager>().InSingletonScope();
			Kernel.Bind<ITranslationProvider>().To<TranslationProvider>().InSingletonScope();
			Kernel.Bind<ITranslationMessenger>().To<TranslationMessenger>().InSingletonScope();
		}
	}
}