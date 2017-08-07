namespace ExampleApp.CompositionRoot.Modules
{
	using Ninject.Modules;
	using Translation.TranslationMessenger;
	using Translation.TranslationSelector;
	using Translation.Translator;
	using View.Translation;

	internal class TranslationModule : NinjectModule
	{
		public override void Load()
		{
			Kernel.Bind<ITranslationSelector>().To<TranslationSelector>().InSingletonScope();
			Kernel.Bind<ITranslator>().To<Translator>().InSingletonScope();
			Kernel.Bind<ITranslationMessenger>().To<TranslationMessenger>().InSingletonScope();
		}
	}
}