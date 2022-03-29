using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesClassNamespace;

namespace MoviesConsoleMenu
{
    class MainClass
    {
        static void Main(string[] args)
        {
            MoviesClass mc = new MoviesClassNamespace.MoviesClass();

            Menu();
        }

        static void Menu()
        {
            bool boolResult = false;
            string strSelectedNumber = "";
            int intSelectedNumber = 0;

            while (!boolResult)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("* Welcome to the Movie Database. *");
                Console.WriteLine("**********************************");
                Console.WriteLine("Please make your selection from the menu as follows:");
                Console.WriteLine("1. Choose a movie to watch.");
                Console.WriteLine("2. Save a new movie in the database");
                Console.WriteLine("3. Exit this menu.");
                Console.WriteLine("**********************************");
                strSelectedNumber = Console.ReadLine();


                boolResult = int.TryParse(strSelectedNumber, out intSelectedNumber);
                if ((intSelectedNumber > 0) && (intSelectedNumber < 4))
                {
                    switch(intSelectedNumber)
                    {
                        case 1:
                            Console.WriteLine("You have selected to choose a movie to watch.");
                            break;
                        case 2:
                            Console.WriteLine("You have selected to save a new movie to the database.");
                            break;
                        case 3:
                            Console.WriteLine("You have selected to Exit the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please select a number between 1 to 3 for the menu items.");
                }
            }


            Console.ReadKey();
        }
    }
}
