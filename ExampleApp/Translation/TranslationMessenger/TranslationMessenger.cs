namespace Translation.TranslationMessenger
{
	using System.Threading;
	using Messenger.Messenger;

	public class TranslationMessenger : Messenger, ITranslationMessenger
	{
		public TranslationMessenger() : base(SynchronizationContext.Current)
		{
		}
	}
}