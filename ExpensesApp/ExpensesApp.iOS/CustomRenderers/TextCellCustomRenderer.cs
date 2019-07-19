using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpensesApp.iOS.CustomRenderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(TextCellCustomRenderer))]
namespace ExpensesApp.iOS.CustomRenderers
{
    public class TextCellCustomRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            // return base.GetCell(item, reusableCell, tv); // comment-out boilerplate return line

            var cell = base.GetCell(item, reusableCell, tv);

            switch(item.StyleId)        // NB StyleId attribute available in TextCell xaml element - use to set Accessory property
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None; // use native iOS TableViewCell.Accessory
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.DetailButton; // checkmark image
                    break;
                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton; // information button
                    break;
                case "detail-disclosure-button":        // chevron shape for fisclosing new information
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;       // information button & chevron disclosure shape
                    break;
                case "disclosure":
                default:
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }
            return cell;
        }
    }
}