namespace ExampleApp.CompositionRoot.Modules
{
	using Common.ArgumentMust;
	using Ninject.Modules;
	using Translation.TranslationMessenger;
	using Translation.TranslationSelector;
	using Translation.Translator;
	using ViewLayer.Translation;

	internal class TranslationModule : NinjectModule
	{
		public override void Load()
		{
			ArgumentMust.NotBeNull(() => Kernel);

			Kernel.Bind<ITranslationSelector>().To<TranslationSelector>().InSingletonScope();
			Kernel.Bind<ITranslator>().To<Translator>().InSingletonScope();
			Kernel.Bind<ITranslationMessenger>().To<TranslationMessenger>().InSingletonScope();
		}
	}
}