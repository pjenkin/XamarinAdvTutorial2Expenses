using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ExpensesApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string db_name = "expenses_db.db3";
            // string folder_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, db_name);   // https://stackoverflow.com/a/26186749/11365317
            // string full_path = Path.Combine(folder_path, db_name);      // db path

            //LoadApplication(new ExpensesApp.App());
            LoadApplication(new ExpensesApp.App(full_path));

        }
    }
}
