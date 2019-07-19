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

            // if ListView had x:Name="listView" in xaml, which is not great MVVM, could use something like listView.SeparatorColor="#efefef"; to set separator to grey in code-behind, instead of using SeparatorColor attribute in xaml 
            // I used xaml's SeparatorColor attribute to fulfil all-grey highlight in https://www.udemy.com/the-advanced-xamarin-developer-masterclass/learn/lecture/14080176#questions/7051972
        }

        protected override void OnAppearing()       // OnAppearing making use of Observable (which happened to be) in the relevant VM - notifying View on any changes
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
            // GetExpenses must of course, be public scope

        }
    }
}