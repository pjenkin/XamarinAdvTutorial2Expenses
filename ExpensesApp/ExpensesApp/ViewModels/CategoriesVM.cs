using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ExpensesApp.ViewModels
{

    class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }        // code-behind for picker list

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }        // use nested class, used as Path for Binding in ItemsSource of ListView

        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();        // initialise member variable
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        /// <summary>
        /// Check in db for all expenses, by category
        /// adding to member CategoryExpensesCollection object an instance 
        /// with sum for this category and this category's % of total for all categories
        /// </summary>
        public void GetExpensesPerCategory()        // public so as to also use from xaml page's code-behind (for C# binding)
        {
            // throw new NotImplementedException();

            // needed new GetExpenses in Expense model class, overloaded to take category parameter

            CategoryExpensesCollection.Clear();             // wipe the class member, ready for an update of current expenses
            float totalExpensesAmount = Expense.GetTotalExpensesAmount();


            foreach(string cat in Categories)
            {
                var expenses = Expense.GetExpenses(cat);
                float expensesAmountInCategory = expenses.Sum(ex => ex.Amount);
                // Using LINQ to sum the expense values for each expense (separately in each category)
                // Make an object for use in xaml Cell

                CategoryExpenses categoryExpenses = new CategoryExpenses()
                {
                    Category = cat,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount    // ratio of this category to all categories
                };

                CategoryExpensesCollection.Add(categoryExpenses);       // add this calculated object to the class member's collection of such
            }

            // needed TotalExpensesAmount in Expense model class

        }

        /// <summary>
        /// Populate the picker list's code-behind with category values
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
    }

    // 2-10 Whole new class within the CategoriesVM class (must this go here?) used for type of ObservableCollection
    public class CategoryExpenses
    {
        public string Category
        {
            get;
            set;
        }

        public float ExpensesPercentage { get; set; }
    }
    
}
