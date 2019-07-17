using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{

    class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }        // code-behind for picker list


        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();        // initialise member variable
            GetCategories();
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

    
}
