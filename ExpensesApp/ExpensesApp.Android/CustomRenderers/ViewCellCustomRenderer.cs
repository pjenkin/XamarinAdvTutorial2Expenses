using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// NB the export attribute for this class has been written over at the top of TextCellCustomRenderer, just for kicks
namespace ExpensesApp.Droid.CustomRenderers
{
    public class ViewCellCustomRenderer : ViewCellRenderer
    {
        private Android.Views.View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;        // there's an initial default background - to be changed by this code

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            // return base.GetCellCore(item, convertView, parent, context);

            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;                    // start by assuming cell d'start not selected
            _defaultBackground = _cell.Background;  // populate with initial background value

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected")     // if event is a selection (either selected or unselected), toggle current status
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.FromHex("#e6e6e6").ToAndroid());     // grey-ish a la iOS cell selection colour
                }
                else
                {
                    _cell.Background = _defaultBackground;
                }
            }
        }
    }
}