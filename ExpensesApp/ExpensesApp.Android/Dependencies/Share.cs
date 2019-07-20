using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]      // NB using Xamarin.Forms.Dependency, not System.Runtime.CompilerServices.Dependency
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public async Task Show(string title, string message, string filePath)
        {
            // throw new NotImplementedException();
        }
    }
}