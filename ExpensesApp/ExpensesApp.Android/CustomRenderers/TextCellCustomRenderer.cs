using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Views;
using ExpensesApp.Droid.CustomRenderers;
//using Foundation;
//using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellCustomRenderer))]// cf 
[assembly: ExportRenderer(typeof(TextCell), typeof(ExpensesApp.Droid.CustomRenderers.TextCellCustomRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class TextCellCustomRenderer : TextCellRenderer
    {
        //public override Android.Views.View GetCellCore(Cell item, UITableViewCell reusableCell, UITableView tv)
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            // return base.GetCellCore(item, convertView, parent, context); // comment-out boilerplate return line
            var cell = base.GetCellCore(item, convertView, parent, context); // comment-out boilerplate return line

            switch (item.StyleId)        // NB StyleId attribute available in TextCell xaml element - use to set Accessory property
            {
                case "none":
                    //cell.Accessory = UITableViewCellAccessory.None; // use native iOS TableViewCell.Accessory
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkSlateBlue);
                    break;
                case "checkmark":
                    //cell.Accessory = UITableViewCellAccessory.DetailButton; // checkmark image
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkKhaki);

                    break;
                case "detail-button":
                    //cell.Accessory = UITableViewCellAccessory.DetailButton; // information button
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkSalmon);

                    break;
                case "detail-disclosure-button":        // chevron shape for fisclosing new information
                    //cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;       // information button & chevron disclosure shape
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkOrchid);

                    break;
                case "disclosure":
                default:
                    // cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    cell.SetBackgroundColor(Android.Graphics.Color.DarkRed);

                    break;
            }
            return cell;
        }
    }
}