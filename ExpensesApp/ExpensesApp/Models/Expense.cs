using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesApp.Models
{
    class Expense
    {
        [PrimaryKey, AutoIncrement]     // SQLite attributes
        public int id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        [MaxLength(25)]
        public string Description { get; set; }

        //        public DateTime? Date { get; set; }             // made nullable to get today's date https://stackoverflow.com/a/23431551/11365317
                public DateTime Date { get; set; }             // video 2-9 set today's date in code-behind instead of nullable/TargetNullValue

        public string Category { get; set; }


        public Expense()
        {

        }

        /// <summary>
        /// Write to local db - record an expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        public static int InsertExpense(Expense expense)
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Insert(expense);      // return number of added rows
            }
        }

        /// <summary>
        /// Read from local db - get list of recorded Expense items
        /// This will enable an ObservableCollection<Expense> to be instantiated in some class using this
        /// </summary>
        public static List<Expense> GetExpenses()
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().ToList();
            }
        }

        /// <summary>
        /// Read from local db - get list of recorded Expense items
        /// Overload to take category parameter (for listing expenses by category)
        /// This will enable an ObservableCollection<Expense> to be instantiated in some class using this
        /// </summary>
        public static List<Expense> GetExpenses(string category)
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().Where(ex => ex.Category == category).ToList();   // get only expenses put down to requested category
            }
        }

        /// <summary>
        /// Get the sum of all recorded expenses as a total value
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static float GetTotalExpensesAmount()
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().ToList().Sum(ex => ex.Amount);   // get *un*filtered / i.e. all expenses & use LINQ to sum
            }
        }
    }
}
