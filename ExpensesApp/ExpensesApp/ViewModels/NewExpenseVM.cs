using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /*
                private DateTime? expenseDate;      // made nullable to get today's date https://stackoverflow.com/a/23431551/11365317

                public DateTime? ExpenseDate        // made nullable to get today's date https://stackoverflow.com/a/23431551/11365317
                {
                    get { return expenseDate; }
                    set { expenseDate = value; OnPropertyChanged("ExpenseDate"); }
                }
        */
        // video 2-9 set today's date in code-behind instead of nullable/TargetNullValue
        // private DateTime? expenseDate;      // made nullable to get today's date https://stackoverflow.com/a/23431551/11365317
        private DateTime expenseDate;          // video 2-9 set today's date in code-behind instead of nullable/TargetNullValue
        //public DateTime? ExpenseDate        // made nullable to get today's date https://stackoverflow.com/a/23431551/11365317
        public DateTime ExpenseDate        // video 2-9 set today's date in code-behind instead of nullable/TargetNullValue
        {
            get { return expenseDate; }
            set { expenseDate = value; OnPropertyChanged("ExpenseDate"); }
        }


        private string expenseCategory;

        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set { expenseCategory = value; OnPropertyChanged("ExpenseCategory"); }
            // NoooooO! typing ExpenseCategory instead of expenseCategory in the setter cost me hours in terms of a malfunctioning Picker (selection crashed app with no exception thrown) for Category :-< !!!
        }

        // Command for MVVM saving an expense record - cf xaml - used as path value in command attribute
        public Command SaveExpenseCommand { get; set; }

        /// <summary>
        /// ObservableCollection added similar to Categories in CategoriesVM
        /// </summary>
        public ObservableCollection<string> Categories { get; set; }    // code-behind for category picker list when using NewExpense page

        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }


        /// <summary>
        /// constructor initialising the VM command for a button to add an expense record
        /// </summary>
        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            ExpenseDate = DateTime.Today;           // video's way of code-behind setting date (instead of using nullable/TargetNullVaue)
            SaveExpenseCommand = new Command(InsertExpense);      // overload command in this case (as with addnewexpense) with InsertExpense action/method
            GetCategories();                        // populate Category picker
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
            var vm = this;
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription

                // TODO not yet saving in Expense object the ExpenseStatus status values of 2-11
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

        /// <summary>
        /// Populate picker list code-behind with categories (when using NewExpense page)
        /// </summary>
        private void GetCategories()
        {
            // throw new NotImplementedException();

            Categories.Clear();
            Categories.Add("Housing");                              // populate member variable with category names
            Categories.Add("Borrowing Repayment");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Transportation");
            Categories.Add("Other");
        }

        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus()       // just for demonstration, as if fetched from internet
             {
                    Name= "Some random data 1",
                    Status = true
            } );
            ExpenseStatuses.Add(new ExpenseStatus()       // just for demonstration, as if fetched from internet
            {
                Name = "Some random data 2",
                Status = false
            });
            ExpenseStatuses.Add(new ExpenseStatus()       // just for demonstration, as if fetched from internet
            {
                Name = "Some random data 3",
                Status = true
            });
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }

            public bool Status { get; set; }
        }
    }
}
