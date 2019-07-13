using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	// public partial class MainPage : ContentPage
	public partial class MainPage : TabbedPage     // we're a tabbed page now! (cf xaml)
	{
		public MainPage ()
		{
			InitializeComponent ();

		}
	}
}