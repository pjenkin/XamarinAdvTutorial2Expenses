
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using ExpensesApp.iOS.CustomRenderers;      // 'using' here for use within attribute's namespace
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// params: handler for renderer (control) to change, with what new renderer - 
// NB 'using' needed for renderer replacement class, even within its own class file, 
// because scope is within a different namespace inside attribute declaration

[assembly: ExportRenderer(typeof(ProgressBar),typeof(CustomProgressBarRenderer ))]        
namespace ExpensesApp.iOS.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        // This class will make iOS progress bars 4 times as tall (somewhat slender by default)
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)        // every time the element is redrawn
        {
            base.OnElementChanged(e);



            // NB parameter 'e' is the original element (before being changed by custom renderer) - its NewElement is the custom rendered version of the element

            
                        if (double.IsNaN(e.NewElement.Progress))        // Progress of 1 is 100%
                        {
                            Control.ProgressTintColor = Color.FromHex("#0089ae").ToUIColor();   // fine if no value yet in this category - greenish
                        }
                        else if (e.NewElement.Progress < 0.3)
                        {   // using brackets cos i d'like em
                            Control.ProgressTintColor = Color.FromHex("#008dd5").ToUIColor();   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
                        }
                        else if (e.NewElement.Progress < 0.5)
                        {   // using brackets cos i d'like em
                            Control.ProgressTintColor = Color.FromHex("#2d76ba").ToUIColor();   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
                        }
                        else if (e.NewElement.Progress < 0.7)
                        {   // using brackets cos i d'like em
                            Control.ProgressTintColor = Color.FromHex("#5a5f9f").ToUIColor();   // increasingly red-der colours as the category has a higher progress/% (of total expenditure) 
                        }
                        else if (e.NewElement.Progress < 0.9)
                        {   // using brackets cos i d'like em
                            Control.ProgressTintColor = Color.FromHex("#b3316a").ToUIColor();   // increasingly red-der colours as the category has a higher progress/% (of total expenditure)
                        }
                        else
                        {   // using brackets cos i d'like em
                            Control.ProgressTintColor = Color.FromHex("#eo1a4f").ToUIColor();   // increasingly red-der colours as the category has a higher progress/% (of total expenditure) 
                        }
                        
            var prog = e.NewElement.Progress;       // diagnostic
            // colour hex values from instructor's preparation

            LayoutSubviews();           // re-scale & re-colour the progress bar
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float x = 1.0f;
            float y = 4.0f;     // 4 times taller - used in transform

            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);    // CG - iOS CoreGraphics
            Transform = transform;      // 'Transform' is a property of the view (UIView)
        }
    }
}