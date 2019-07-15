using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    class ExpensesVM
    {
        public ObservableCollection<Expense> Expenses { get; set; } // NB not possible to assign directly to ObservableCollection, hence must loop & push

        public Command AddExpenseCommand { get; set; }              // used as a path value in xaml binding command attribute



        public ExpensesVM()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);      // various overloads - in this case just set the action/method AddExpense (qv below)
            GetExpenses();
        }

        /// <summary>
        /// bespoke method to loop through expenses from db & assign to class member
        /// NB not possible to assign directly to ObservableCollection, hence must loop & push
        /// </summary>
        private void GetExpenses()
        {
            // throw new NotImplementedException();
            var expenses = Expense.GetExpenses();
            // NB not possible to assign directly to ObservableCollection, hence must loop & push

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);      // add 1-by-1
            }
        }

        /// <summary>
        /// For starting a new expense dialogue from a button in this page, using a command
        /// </summary>
        public void AddExpense()
        {
            // Navigate, using the application context, to a new-expense page
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());        // NB make sure to use Xamarin.Forms. for Application
        }


    }
}
