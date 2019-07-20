using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Interfaces
{
    public interface IShare     // share data with other applications (platform-agnostic)
    {
        Task Show(string title, string message, string filePath);   // declare (don't implement here) method - to be implemented in subclass
    }
}
