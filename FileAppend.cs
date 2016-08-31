using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //Class for appending new data to the "Parts.csv" file
    class FileAppend
    {
        //Declared variables that are used by the methods in this class.
        private static string s_BrandR, s_BrandA, s_BrandB, s_BrandC;
        //Method to check if new parts that are to be added to the "Parts.csv" file, already exist
        //in the file or not.
        public static void CheckDatabase()
        {
            MessageManager c_Message = new MessageManager();

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
            Console.Clear();
            RetryBrandR:
            s_BrandR = c_Message.UpdateBrandR();
            for (int i_count = 0; i_count < as_Parts.GetLength(1); i_count++)
            {
                if (as_Parts[0, i_count] == s_BrandR) { c_Message.PartExistsError(); goto RetryBrandR; }
            }
            RetryBrandA:
            s_BrandA = c_Message.UpdateBrandA();
            for (int i_count = 0; i_count < as_Parts.GetLength(1); i_count++)
            {
                if (as_Parts[1, i_count] == s_BrandA) { c_Message.PartExistsError(); goto RetryBrandA; }
            }
            RetryBrandB:
            s_BrandB = c_Message.UpdateBrandB();
            for (int i_count = 0; i_count < as_Parts.GetLength(1); i_count++)
            {
                if (as_Parts[2, i_count] == s_BrandB) { c_Message.PartExistsError(); goto RetryBrandB; }
            }
            RetryBrandC:
            s_BrandC = c_Message.UpdateBrandC();
            for (int i_count = 0; i_count < as_Parts.GetLength(1); i_count++)
            {
                if (as_Parts[3, i_count] == s_BrandC) { c_Message.PartExistsError(); goto RetryBrandC; }
            }
            c_Message.SeeUpdatedfile();
            AppendToFile();
        }
        //Method to append checked user input to the "Parts.csv" file, and also display the updated
        //"Parts.csv" file on the screen.
        public static void AppendToFile()
        {
            string s_Append;
            s_Append = "\r\n" + s_BrandR + "," + s_BrandA + "," + s_BrandB + "," + s_BrandC;
            System.IO.File.AppendAllText("Parts.csv", s_Append);

            string s_FileContents = System.IO.File.ReadAllText("Parts.csv");

            Console.Clear();
            Console.WriteLine("The file " + "Parts.csv" + " now contains:\r\n");
            Console.WriteLine(s_FileContents + "\r\n");
            Console.WriteLine();
            Console.Write("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
