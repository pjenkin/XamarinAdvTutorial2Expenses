using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
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
        /// <summary>
        /// Share a file (Android version)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Task Show(string title, string message, string filePath)
        {
            // throw new NotImplementedException();

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.guidebookplus.ExpensesApp.provider", new Java.IO.File(filePath));   // NB Xamarin.Forms file context, not Android; Java.IO.File for local file

            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraSubject, message);          // good old PutExtra to pass data to next Activity alongside execution of intent
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);      // NB grantUriPermission in AndroidManifest provider element
            Android.App.Application.Context.StartActivity(chooserIntent);

            // NB no await/async in Android (unlike iOS qv) so just return a Task
            return Task.FromResult(true);
        }
    }
}