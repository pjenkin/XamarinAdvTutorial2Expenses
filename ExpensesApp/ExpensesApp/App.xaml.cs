using ExpensesApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExpensesApp
{
    public partial class App : Application
    {
        public static string DatabasePath;      // path for the SQLite db

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage()); // cf ContentPage, MasterDetailPage, TabbedPage, CarouselPage

        }

        /// <summary>
        ///  constructor override with string parameter for databasePath (for use with local db e.g. SQLite)
        /// </summary>
        /// <param name="databasePath"></param>
        public App(string databasePath)
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage()); // cf ContentPage, MasterDetailPage, TabbedPage, CarouselPage

            DatabasePath = databasePath;                    // initialise db path from constructor parameter
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
