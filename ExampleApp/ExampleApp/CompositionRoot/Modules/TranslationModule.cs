namespace ExampleApp.CompositionRoot.Modules
{
	using Common.ArgumentMust;
	using Ninject.Modules;
	using Translation.TranslationMessenger;
	using Translation.TranslationProvider;
	using Translation.TranslationSelector;
	using ViewLayer.Translation;

	internal class TranslationModule : NinjectModule
	{
		public override void Load()
		{
			ArgumentMust.NotBeNull(() => Kernel);

			Kernel.Bind<ITranslationSelector>().To<TranslationSelector>().InSingletonScope();
			Kernel.Bind<ITranslationProvider>().To<TranslationProvider>().InSingletonScope();
			Kernel.Bind<ITranslationMessenger>().To<TranslationMessenger>().InSingletonScope();
		}
	}
}