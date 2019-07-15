using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{

    class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }


        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();        // initialise member variable
            GetCategories();
        }

        private void GetCategories()
        {
            // throw new NotImplementedException();

            Categories.Clear();
            Categories.Add("Housing");                              // populate member variable with category names
            Categories.Add("Debt wtf");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Transportation");
            Categories.Add("Other");
        }
    }
}
