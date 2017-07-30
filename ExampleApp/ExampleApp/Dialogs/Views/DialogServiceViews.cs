using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MvvmDialogs.Views;

namespace MvvmDialogs
{
    using System.Windows;

    public static class DialogServiceViews
    {
        private static readonly List<IView> InternalViews = new List<IView>();
        
        internal static IEnumerable<IView> Views => InternalViews.Where(view => view.IsAlive).ToArray();

        /// <summary>
        /// Registers specified view.
        /// </summary>
        /// <param name="view">The view to register.</param>
        internal static void Register(IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            
            // Get owner window
            Window owner = view.GetOwner();
            if (owner == null)
            {
                // Perform a late register when the view hasn't been loaded yet.
                // This will happen if e.g. the view is contained in a Frame.
                view.Loaded += LateRegister;
                return;
            }

            PruneInternalViews();

            // Register for owner window closing, since we then should unregister view reference
            owner.Closed += OwnerClosed;

            Logger.Write($"Register view {view.Id}");
            InternalViews.Add(view);
            Logger.Write($"Registered view {view.Id} ({InternalViews.Count} registered)");
        }

        /// <summary>
        /// Clears the registered views.
        /// </summary>
        internal static void Clear()
        {
            Logger.Write("Clearing views");
            InternalViews.Clear();
            Logger.Write("Cleared views");
        }

        /// <summary>
        /// Unregisters specified view.
        /// </summary>
        /// <param name="view">The view to unregister.</param>
        private static void Unregister(IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            
            PruneInternalViews();

            Logger.Write($"Unregister view {view.Id}");
            InternalViews.RemoveAll(registeredView => ReferenceEquals(registeredView.Source, view.Source));
            Logger.Write($"Unregistered view {view.Id} ({InternalViews.Count} registered)");
        }

        /// <summary>
        /// Callback for late view register. It wasn't possible to do a instant register since the
        /// view wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private static void LateRegister(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.Source as FrameworkElement;
            if (frameworkElement != null)
            {
                // Unregister loaded event
                frameworkElement.Loaded -= LateRegister;

                // Register the view
                var view = frameworkElement as IView;
                if (view != null)
                {
                    Register(view);
                }
                else
                {
                    Register(new ViewWrapper(frameworkElement));    
                }
            }
        }

        /// <summary>
        /// Handles owner window closed. All views acting within the closed window should be
        /// unregistered.
        /// </summary>
        private static void OwnerClosed(object sender, EventArgs e)
        {
            var owner = sender as Window;
            if (owner != null)
            {
                // Find views acting within closed window
                IView[] windowViews = Views
                    .Where(view => ReferenceEquals(view.GetOwner(), owner))
                    .ToArray();
                
                // Unregister Views in window
                foreach (IView windowView in windowViews)
                {
                    Logger.Write($"Window containing view {windowView.Id} closed");
                    Unregister(windowView);
                }
            }
        }

        private static void PruneInternalViews()
        {
            Logger.Write($"Before pruning ({InternalViews.Count} registered)");
            InternalViews.RemoveAll(reference => !reference.IsAlive);

            Logger.Write($"After pruning ({InternalViews.Count} registered)");
        }
    }
}