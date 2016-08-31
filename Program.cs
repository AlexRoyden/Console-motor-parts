using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        //On startup the main method, calls the Class "MessageManager" to use it's method "DatabaseOptions".
        static void Main(string[] args)
        {
            MessageManager c_Message = new MessageManager();
            MessageManager.DatabaseOptions();            
        }
    }
}
