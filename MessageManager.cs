using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //This class contains the user prompts and messages from the other classes. 
    class MessageManager
    {
        //This method is called at the program startup.
        //It gives the user the option to search for the corresponding part, or to update the database.
        public static void DatabaseOptions()
        {
            string s_option;
            int i_option;
            Console.Clear();
            Console.WriteLine("****** Repco Auto Parts ******");
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Repco Auto Parts Database.");
            Console.WriteLine("");
            Console.WriteLine("To search database for parts, type 1 and press enter.");
            Console.WriteLine("");
            Console.WriteLine("To add new parts to the database, type 2 and press enter.");
            Console.WriteLine("");
            s_option = Console.ReadLine();
            int.TryParse(s_option, out i_option);
            if (i_option == 1) { FindPart.CheckingPartNumbers(); }
            if (i_option == 2) { FileAppend.CheckDatabase(); }
            if (i_option != 1 && i_option != 2) { WrongOption(); }
            if (i_option < 1) { WrongOption(); }
           
        }
        //Method to get the manufacturer brand name from the user.
        //called from the "FindPart" class.
        public string GetBrand()
        {
            Console.WriteLine("****** Repco Auto Parts ******");
            Console.WriteLine();
            Console.WriteLine("To find The model number of the repco part you require,"); 
            Console.WriteLine("please enter brand name and model number of a different manufacturer.");
            Console.WriteLine();
            Console.WriteLine("Please enter manufacturer brand A or B or C and press enter.");
            return Console.ReadLine().ToUpper();
        }
        //Method to get the part model number from the user.
        //called from the "FindPart" class and the "FileAppend" class.
        public string GetModel()
        {
            Console.Write("Please enter model number:");
            return Console.ReadLine().ToUpper();
        }
        //Called from the "FindPart" class, gives error message if user enters an unknown manufactures brand name.
        public static void UnknownBrandError()
        {
            Console.WriteLine("Selected brand does not exist");
            Console.WriteLine();
            Console.WriteLine("Press any key to re-try.");
            Console.ReadKey();
            Console.Clear();
            FindPart.CheckingPartNumbers();
        }
        //called from the "FindPart" class, gives error message if user enters a model number that,
        //has no match to the numbers in the "Parts.csv" file.
        public void UnknownModelError()
        {
            string s_Option;
            int i_Option;
            Console.WriteLine();
            Console.WriteLine("Model number does not exist.");
            Console.WriteLine("");
            Console.WriteLine("Press 1 to re-enter brand and model.");
            Console.WriteLine("");
            Console.WriteLine("Press 2 to update database.");
            s_Option = Console.ReadLine();
            int.TryParse(s_Option, out i_Option);
            if (i_Option == 1) { FindPart.CheckingPartNumbers(); }
            if (i_Option == 2) { FileAppend.CheckDatabase(); }
        }
        //Called by the "DatabaseOptions" method. displaed if user enters any other option than,
        //search for part, or update database.
        public static void WrongOption()
        {
            Console.Clear();
            Console.WriteLine("Option not available!");
            Console.WriteLine("");
            Console.Write("Press any key to continue");
            Console.ReadKey();

            DatabaseOptions();
        }
        //Called from the "FileAppend" class, prompts user to enter Repco part model number.
        public string UpdateBrandR()
        {
            Console.Clear();
            Console.WriteLine("****** Repco Auto Parts ******");
            Console.WriteLine();
            Console.WriteLine("Please enter model number for Repco part.");
            return Console.ReadLine().ToUpper();
        }
        //Called from the "FileAppend" class, prompts user to enter brand A part, model number.
        public string UpdateBrandA()
        {
            Console.WriteLine("Please enter model number for brand A part.");
            return Console.ReadLine().ToUpper();
        }
        //Called from the "FileAppend" class, prompts user to enter brand B part, model number.
        public string UpdateBrandB()
        {
            Console.WriteLine("Please enter model number for brand B part.");
            return Console.ReadLine().ToUpper();
        }
        //Called from the "FileAppend" class, prompts user to enter brand C part, model number.
        public string UpdateBrandC()
        {
            Console.WriteLine("Please enter model number for brand C part.");
            return Console.ReadLine().ToUpper();
        }
        //Called by "FileAppend" class, if user enters a model number to append to the "Parts.csv" file,
        //and the part already exists in the file this error message is displayed.
        public void PartExistsError()
        {
            Console.WriteLine("The model you have entered already exists on the database");
            Console.WriteLine();
            Console.WriteLine("Press any key to retry");
            Console.ReadKey();
            //FileAppend.CheckDatabase();
        }
        //Called by the "FileAppend" class, give the user a prompt to display the contents of 
        //the updated "Parts.csv" file, on the screen.
        public void SeeUpdatedfile()
        {
            Console.Write("Press any key to see updated database.");
            Console.ReadKey();
        }
    }
}
