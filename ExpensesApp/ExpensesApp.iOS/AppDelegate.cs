using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExpensesApp.iOS.Dependencies;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace ExpensesApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            string db_name = "expenses_db.db3";
            string folder_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string full_path = Path.Combine(folder_path, db_name);      // db path

            // Register dependencies for DI here
            DependencyService.Register<Share>();        // register our Share (share data between platforms) as a dependency

            // LoadApplication(new App());
            LoadApplication(new App(full_path));        // launch app using db path (2nd constructor overload with string parameter)


            return base.FinishedLaunching(app, options);
        }
    }
}
