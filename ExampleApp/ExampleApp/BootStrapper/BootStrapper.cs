namespace ExampleApp.BootStrapper
{
	using System.Reflection;
	using IoC;
	using MatLabImpl;
	using Translation.TranslationMessenger;
	using Translation.TranslationSelector;
	using Translation.Translator;
	using View.Translation;
	using ViewModel.Main;
	using ViewModelImpl.Main;

	public class BootStrapper
	{
		private readonly IIoCContainer _container;

		public BootStrapper(IIoCContainer container)
		{
			_container = container;

			// TODO: Modules need to be sourced out!

			// ServiceLocatorModule
			// Some Reflection Hacks - need to fix this
			var method = typeof(ServiceLocator).GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.NonPublic);
			method.Invoke(null, new object[] {container});

			// TranslationModule
			_container.RegisterSingleton<ITranslationSelector, TranslationSelector>();
			_container.RegisterSingleton<ITranslator, Translator>();
			_container.RegisterSingleton<ITranslationMessenger, TranslationMessenger>();

			// MainModule
			_container.RegisterSingleton<IMainWindowViewModel, MainWindowViewModel>();

			// MatLabModule
			_container.RegisterTransient<MatLabBase>();
			// var temp = new MatLabBase();
			// var res = MatLabBase.GetFuncResult();
		}
	}
}