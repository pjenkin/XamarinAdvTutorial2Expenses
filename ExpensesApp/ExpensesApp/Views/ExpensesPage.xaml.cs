using ExpensesApp.ViewModels;
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
	public partial class ExpensesPage : ContentPage
	{
        ExpensesVM ViewModel;

		public ExpensesPage ()
		{
			InitializeComponent ();

            ViewModel = Resources["vm"] as ExpensesVM;      // refer to xaml static resource dictionary entry by its Key string value
		}


        // As with Categories page code-behind, override OnAppearing to use Observable in C# binding

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenses();       // must ensure GetExpenses is public in scope
        }
    }
}