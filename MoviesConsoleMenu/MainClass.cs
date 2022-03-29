using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesClassNamespace;
using System.IO;
using System.Globalization;

namespace MoviesConsoleMenu
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                MoviesClass mc = new MoviesClassNamespace.MoviesClass();
                mc.Name = "Class of the Titans";
                mc.YearReleased = DateTime.Now; //new DateTime(2010, 8, 9);

                Menu(mc);

                //for Demo
                //LogToErrorFile(DateTime.Now, ", "+"Hello Error!");
                //mc.WriteToDBtextFile(mc.Name, mc.YearReleased, mc.Genre, mc.TimeWatched);

                Console.ReadKey();
            }
            catch (Exception exc)
            {
                bool boolResult = LogToErrorFile(DateTime.Now, exc.ToString());
            }
        }

        static void Menu(MoviesClass mc)
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
                Console.WriteLine("1. Enter Movie watched.");
                Console.WriteLine("2. Search for movie.");
                Console.WriteLine("3. Show listing of movies watched.");
                Console.WriteLine("4. Exit this menu.");
                Console.WriteLine("**********************************");
                strSelectedNumber = Console.ReadLine();


                boolResult = int.TryParse(strSelectedNumber, out intSelectedNumber);
                if ((intSelectedNumber > 0) && (intSelectedNumber < 5))
                {
                    string strTemp = "";
                    boolResult = false;

                    switch (intSelectedNumber)
                    {
                        case 1:
                            MenuChoiceOne(mc);
                            break;
                        case 2:
                            Console.WriteLine("You selected to search for a movie in the DB.");

                            break;
                        case 3:
                            mc.ReadFromDBtextFile();
                            break;
                        case 4:
                            //for exiting the menu
                            //Console.WriteLine("You have selected to Exit the menu.");
                            break;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Please select a number between 1 to 4 for the menu items.");
                }
            }

            Console.WriteLine("Press ENTER key to exit");
            Console.ReadKey();
        }

        static void MenuChoiceOne(MoviesClass mc)
        {
            bool boolResult = false;
            string strTemp = "";
            //Name
            Console.WriteLine("What is the name of the movie.");
            mc.Name = Console.ReadLine();
            //Year Released
            while (!boolResult)
            {
                // Console.WriteLine("When was the movie released? Type the date in this format (DD/MM/YYYY)");
                Console.WriteLine("What was the year that the movie released?");
                strTemp = Console.ReadLine();
                strTemp = "01/01/" + strTemp;
                DateTime YR = DateTime.Now;
                boolResult = DateTime.TryParse(strTemp, out YR);
                if (boolResult == true)
                {
                    mc.YearReleased = YR;
                    Console.WriteLine("The year released that will be saved to the DB file is: " + YR.Year.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid year typed. Try again.");
                }
            }
            //Genre
            Console.WriteLine("What is the Genre of the movie? Enter either Drama, Comedy, Action, SciFi, Fiction, or Horror.");
            mc.Genre = Console.ReadLine();
            //public enum MovieCategory
            //{
            //    Drama,  //0
            //    Comedy, //1
            //    Action, //2
            //    SciFi,  //3
            //    Fiction, //4
            //    Horror   //5
            //}
            //Time Watched
            boolResult = false;
            while (!boolResult)
            {
                Console.WriteLine("When did you last watch this movie? \r\nPlease enter the time and date in this format: ddd dd MMM h:mm tt yyyy\r\nFor example: Mon 16 Jun 8:30 AM 2008");//
                strTemp = Console.ReadLine();
                //strTemp = "01/01/" + strTemp;
                DateTime dt = DateTime.Now;
                string format = "ddd dd MMM h:mm tt yyyy";
                boolResult = DateTime.TryParseExact(strTemp, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);//DateTime.TryParse(strTemp, out dt);
                if (boolResult == true)
                {
                    mc.TimeWatched = dt;
                    Console.WriteLine("The last time you watched this movie, that will be saved to the DB file, is: " + dt.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid year typed.");
                }
            }
        }
        static bool LogToErrorFile(DateTime dt, string strErrorMessage)
        {
            bool boolSuccesful = false;

            try
            {
                using (StreamWriter writer = new StreamWriter("logFile.txt", true))
                {
                    writer.Write(dt.ToString());
                    writer.WriteLine(strErrorMessage);
                }
                boolSuccesful = true;
            }
            catch
            {
                boolSuccesful = false;
            }

            return boolSuccesful;
        }
    }
}


