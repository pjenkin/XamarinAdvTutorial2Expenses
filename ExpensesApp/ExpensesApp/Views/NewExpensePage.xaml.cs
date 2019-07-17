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
	public partial class NewExpensePage : ContentPage
	{
        NewExpenseVM ViewModel;

		public NewExpensePage ()
		{
			InitializeComponent ();
            ViewModel = Resources["vm"] as NewExpenseVM;        // fish out the static resource from the dictionary by Key, "vm"
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenseStatus();

            // enclosing TableSection could be defined in xaml but generated here in C# code-behind - neater in leaving previous xaml layout undisturbed
            var section = new TableSection("Statuses");

            // I'd rather do this with a for loop
            int count = 0;
            foreach (var expenseStatus in ViewModel.ExpenseStatuses)
            {
                var cell = new SwitchCell { Text = expenseStatus.Name };
                // simple assignation of cell.On=expenseStatus.Status would *not* be binding ...

                // ... so make a Binding in C# code - cf the xaml way, with Source (to VM) and Path (method or property member eg Observable)
                Binding binding = new Binding();
                binding.Source = ViewModel.ExpenseStatuses[count];      // iterate through each individual row (as per ItemsSource)
                binding.Path = "Status";      // bind Path by using string name of property - cf xaml
                binding.Mode = BindingMode.TwoWay;
                // could set binding.Converter to process boolean to integer a la IEValueConverter
                cell.SetBinding(SwitchCell.OnProperty, binding);

                section.Add(cell);

                count++;                
                // i.e. 1 binding for each record in ExpensesStatuses
            }

            expenseTableView.Root.Add(section);     // Add the assembled section (of cells) to the element named expenseTableView
            // NB expenseTableView was a TableView element named with x:Name (hence no C# declaration) - not the done thing in MVVM if binding working ok
        }
    }
}