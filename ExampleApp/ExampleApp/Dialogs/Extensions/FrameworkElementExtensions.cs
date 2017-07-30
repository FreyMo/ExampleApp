namespace Dialogs.Extensions
{
	using System.Windows;
	using CommonUtilities.ArgumentMust;
	using CommonUtilities.Extensions;

	internal static class FrameworkElementExtensions
    {
	    internal static Window GetOwner(this FrameworkElement frameworkElement)
	    {
			ArgumentMust.NotBeNull(() => frameworkElement);

			return frameworkElement.As<Window>() ?? Window.GetWindow(frameworkElement);
		}
    }
}