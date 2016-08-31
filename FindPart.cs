using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //This is a class for searching The "Parts.csv" file to give the user the name of the
    //repco part required.
    class FindPart
    {
        //This is a method which creates 2-dimensional array using data stored in the "Parts.csv" file,
        //It then takes user input for parts produced by other manufacturers, and then returns the model
        //number of the corresponding repco part.
        public static void CheckingPartNumbers()
        {
            //This line declares the class MessageManager to be usable by this class.
            MessageManager c_Message = new MessageManager();
            //The following section of code take the data from the "Parts.scv" file,
            //Then converts it to a 2-dimensional array.
            string s_Brand, s_Model, s_Output;
            string[] as_AllContentByLine = System.IO.File.ReadAllLines("Parts.csv");
            string[,] as_Parts = new string[4, as_AllContentByLine.Length];

            for (int i_count = 0; i_count < as_AllContentByLine.Length; i_count++)
            {
                string[] as_temp = as_AllContentByLine[i_count].Split(',');

                as_Parts[0, i_count] = as_temp[0];
                as_Parts[1, i_count] = as_temp[1];
                as_Parts[2, i_count] = as_temp[2];
                as_Parts[3, i_count] = as_temp[3];
            }
            //The following section of code takes the user input, checks it against the values in the array,
            //and returns the corresponding repco part.
            Console.Clear();
            s_Brand = c_Message.GetBrand();
            if (s_Brand != "A" && s_Brand != "B" && s_Brand != "C") { MessageManager.UnknownBrandError(); }

            s_Model = c_Message.GetModel();

            s_Output = "";

            for (int i_count = 0; i_count < as_Parts.GetLength(1); i_count++)
            {
                switch (s_Brand)
                {
                    case "A": if (as_Parts[1, i_count] == s_Model) { s_Output = as_Parts[0, i_count]; }; break;
                    case "B": if (as_Parts[2, i_count] == s_Model) { s_Output = as_Parts[0, i_count]; }; break;
                    case "C": if (as_Parts[3, i_count] == s_Model) { s_Output = as_Parts[0, i_count]; }; break;
                }
            }
            //If user input has no match to the file this line will call the MessageManager class
            //to display an error message, which includes options for the user.
            if (s_Output.Length < 1) { c_Message.UnknownModelError(); }
            //This block of code displays the corresponding repco part to the screen.
            Console.WriteLine();
            Console.WriteLine("Repco model number:" + s_Output);
            Console.WriteLine();
            Console.Write("Press any key to continue");
            Console.ReadKey();
            MessageManager.DatabaseOptions();

        }

    }
}
