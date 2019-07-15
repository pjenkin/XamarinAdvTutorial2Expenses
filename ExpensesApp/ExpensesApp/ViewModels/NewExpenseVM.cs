using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    class NewExpenseVM : INotifyPropertyChanged
    {
        /*
                public string Name { get; set; }

                public float Amount { get; set; }

                [MaxLength(25)]
                public string Description { get; set; }

                public DateTime Date { get; set; }

                public string Category { get; set; }
        */

        private string expenseName;

        public string ExpenseName
        {
            get { return expenseName; }
            set { expenseName = value;
                OnPropertyChanged("ExpenseName"); }
        }

        private float expenseAmount;

        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");

            }
        }

        private string expenseDescription;

        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set { expenseDescription = value; OnPropertyChanged("ExpenseDescription"); }
        }


        private DateTime expenseDate;

        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set { expenseDate = value; OnPropertyChanged("ExpenseDate"); }
        }

        private string expenseCategory;

        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set { ExpenseCategory = value; OnPropertyChanged("ExpenseCategory"); }
        }


        public NewExpenseVM()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;     // Alt+Enter at class to generate boilerplate

        private void OnPropertyChanged(string propertyName)     // added by hand as per notes 12-98
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  // fired on change so that event PropertyChange triggered
            }
        }

        /// <summary>
        /// Insert a new expense record to the db
        /// </summary>
        public void InsertExpense()
        {
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            Expense.InsertExpense(expense);
        }


    }
}
