using System;
using System.Collections.Generic;
using System.Diagnostics; // For measuring execution time
namespace RequestsQueue
{

    class Program
    {
        static void Main(string[] args)
        {

            List<String> StringDataRequests = FileHandling.ReadFile("C:\\Users\\avira\\source\\repos\\RequestsQueue\\ColaSolicitudes\\data.txt");



           

           
            Console.WriteLine("enter -1 for manual execution. Otherwise, select 10, 100, 1000 or 10000");
            int autoOption = Convert.ToInt32(Console.ReadLine());

            Menu.ChooseOptionMenu(autoOption);

            
            

           

            
            
        }
    }
}