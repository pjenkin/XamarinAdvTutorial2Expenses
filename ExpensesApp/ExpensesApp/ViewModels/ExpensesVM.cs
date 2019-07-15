using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    class ExpensesVM
    {
        public ObservableCollection<Expense> Expenses { get; set; } // NB not possible to assign directly to ObservableCollection, hence must loop & push

        public ExpensesVM()
        {
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
    }
}
