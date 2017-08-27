namespace ExampleApp.CompositionRoot
{
	using IoC;
	using MatLabImpl;
	using Translation.TranslationMessenger;
	using Translation.TranslationSelector;
	using Translation.Translator;
	using View.Translation;
	using ViewModel.Main;
	using ViewModelImpl.Main;

	public class CompositionRoot
	{
		private readonly IIoCContainer _container;

		public CompositionRoot(IIoCContainer container)
		{
			_container = container;

			// TODO: Modules need to be sourced out!

			// ServiceLocatorModule
			var creator = new Creator(container);

			// TranslationModule
			_container.RegisterSingleton<ITranslationSelector, TranslationSelector>();
			_container.RegisterSingleton<ITranslator, Translator>();
			_container.RegisterSingleton<ITranslationMessenger, TranslationMessenger>();

			// MainModule
			_container.RegisterSingleton<IMainWindowViewModel, MainWindowViewModel>();

			// MatLabModule
			var temp = new MatLabBase();
			var res = MatLabBase.GetFuncResult();
		}
	}
}