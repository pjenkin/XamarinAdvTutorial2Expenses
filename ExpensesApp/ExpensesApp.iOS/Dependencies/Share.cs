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
        public async Task Show(string title, string message, string filePath)
        {
            // throw new NotImplementedException();
        }
    }
}