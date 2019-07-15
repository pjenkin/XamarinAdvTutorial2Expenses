using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    class NewExpenseVM : INotifyPropertyChanged
    {



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

        // Command for MVVM saving an expense record - cf xaml - used as path value in command attribute
        public Command SaveExpenseCommand { get; set; }


        /// <summary>
        /// constructor initialising the VM command for a button to add an expense record
        /// </summary>
        public NewExpenseVM()
        {
            SaveExpenseCommand = new Command(InsertExpense);      // overload command in this case (as with addnewexpense) with InsertExpense action/method
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

            int response = Expense.InsertExpense(expense);      // try adding an expense record

            if (response > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();     // NB PopAsync from back stack in application  - ie go back to previous page
                // NB using Xamarin.Forms.Application *not* Xamarin.Forms.PlatformConfiguration.AndroidSpecific.Application
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No expense items were inserted", "OK");
            }
        }


    }
}
