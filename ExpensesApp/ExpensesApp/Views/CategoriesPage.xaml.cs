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
	public partial class CategoriesPage : ContentPage       // NB this is the content page in the xaml
	{

        CategoriesVM ViewModel;         // to bind from C#, first have a member referring to the relevant ViewModel

		public CategoriesPage ()
		{
			InitializeComponent ();

            ViewModel = Resources["vm"] as CategoriesVM;    // get the VM resource using its Key string defined in xaml (type Object as default, hence cast)
		}

        protected override void OnAppearing()       // OnAppearing making use of Observable (which happened to be) in the relevant VM - notifying View on any changes
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
            // GetExpenses must of course, be public scope

        }
    }
}