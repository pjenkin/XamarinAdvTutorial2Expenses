
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

            LayoutSubviews();           //re-scale the progress bar
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