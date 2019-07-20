using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesApp.Interfaces;
using Foundation;
using UIKit;
using Xamarin.Forms;
using ExpensesApp.iOS.Dependencies;

[assembly: Dependency(typeof(Share))]         // NB using Xamarin.Forms.Dependency, not System.Runtime.CompilerServices.Dependency
namespace ExpensesApp.iOS.Dependencies
{
    public class Share : IShare
    {
        /// <summary>
        /// Share a file (iOS version)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task Show(string title, string message, string filePath)
        {
            // throw new NotImplementedException();

            // NSObjects are native to iOS - useful to use DI therefore

            var viewController = GetVisibleViewController();
            var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) };
            var activityController = new UIActivityViewController(items, null);

            if (activityController.PopoverPresentationController != null)
            {
                activityController.PopoverPresentationController.SourceView = viewController.View;
            }

            await viewController.PresentViewControllerAsync(activityController, true);      // ViewController with our file items
        }

        /// <summary>
        /// Used with Dependency injection - iOS specific to ViewControllers
        /// 
        /// </summary>
        /// <returns>current ViewController as UIViewController</returns>
        private UIViewController GetVisibleViewController()
        {
            // Prepare to get the kind of iOSViewController - get the current view sort-of-context-container-thing
            var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;  // get the visible ViewController ie. the page seen (when using iOS); from iOS UI Kit

            // Now return the actual viewController in use at this time
            if (rootViewController.PresentedViewController == null)
            {
                return rootViewController;
            }

            if (rootViewController.PresentedViewController is UINavigationController)
                return ((UINavigationController) rootViewController.PresentedViewController).TopViewController;

            if (rootViewController.PresentedViewController is UITabBarController)
                return ((UITabBarController)rootViewController.PresentedViewController).SelectedViewController;
            // Return not the TabBarController itself but the ViewController selected from the tabs
            return rootViewController.PresentedViewController;
        }

        
    }
}