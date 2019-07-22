using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(CustomProgressBarRenderer))]  // NB use Xamarin.Forms.PogressBar not Android.Widget.ProgressBar; also 'using' CustomRenderers itself (for attribute outside namespace)
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer()
        {
            // 'base' superclass needed or no?
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            // NB parameter 'e' is the original element (before being changed by custom renderer) - its NewElement is the custom rendered version of the element


            if (double.IsNaN(e.NewElement.Progress))        // Progress of 1 is 100%
            {
                //Control.ProgressTintColor = Color.FromHex("#0089ae").ToUIColor();   // fine if no value yet in this category - greenish
                //var color = Color.FromHex("#0089ae").ToAndroid();

                //ViewCompat.SetBackgroundTintList(Control, ColorStateList.ValueOf(color));       // https://stackoverflow.com/a/47566740/11365317


                ViewCompat.SetBackgroundTintList(Control, ColorStateList.ValueOf(Color.FromHex("#0089ae").ToAndroid()));       // https://stackoverflow.com/a/47566740/11365317

                //Control.ProgressDrawable.SetTint(color);   // fine if no value yet in this category - greenish

                ////Control.ProgressDrawable.SetTint(Color.FromHex("#0089ae").ToAndroid());   // fine if no value yet in this category - greenish

            }
            else if (e.NewElement.Progress < 0.3)
            {   // using brackets cos i d'like em
                Control.ProgressDrawable.SetTint(Color.FromHex("#008dd5").ToAndroid());   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
            }
            else if (e.NewElement.Progress < 0.5)
            {   // using brackets cos i d'like em
                Control.ProgressDrawable.SetTint(Color.FromHex("#2d76ba").ToAndroid());   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
            }
            else if (e.NewElement.Progress < 0.7)
            {   // using brackets cos i d'like em
                Control.ProgressDrawable.SetTint(Color.FromHex("#5a5f9f").ToAndroid());   // increasingly red-der colours as the category has a higher progress/% (of total expenditure) 
            }
            else if (e.NewElement.Progress < 0.9)
            {   // using brackets cos i d'like em
                Control.ProgressDrawable.SetTint(Color.FromHex("#b3316a").ToAndroid());   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
            }
            else
            {   // using brackets cos i d'like em
                Control.ProgressDrawable.SetTint(Color.FromHex("#eo1a4f").ToAndroid());   // increasingly red-der colours as the category has a higher progress/% (of total expenditure) 
            }

            Control.ScaleY = 4.0f;          // NB no affine transform required to scale control in Android (as would be in iOS)
        }
    }

}