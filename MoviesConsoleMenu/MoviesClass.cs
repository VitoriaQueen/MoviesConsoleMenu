using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MoviesClassNamespace
{
    public class MoviesClass
    {
        string strMovieDiaryFile = "MovieDiary.txt";
        string _name = "";
        DateTime _yearReleased = new DateTime();
        //string _description = "";
        //MovieCategory _genre = MovieCategory.Drama;
        string _genre = "";
        DateTime _timeWatched = new DateTime();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public DateTime YearReleased
        {
            get
            {
                return _yearReleased;
            }
            set
            {
                _yearReleased = value;
            }
        }

        public string Genre   //MovieCategory enum
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }

        public DateTime TimeWatched
        {
            get
            {
                return _timeWatched;
            }
            set
            {
                _timeWatched = value;
            }
        }

        public bool WriteToDBtextFile(string Name, DateTime YearReleased, string Genre, DateTime TimeWatched)
        {
            bool boolSuccesful = false;
            string strWhatToWriteToDB = "";

            try
            {
                using (StreamWriter writer = new StreamWriter(strMovieDiaryFile, true))
                {
                    //writer.Write(dt.ToString());
                    strWhatToWriteToDB = Name + ", " + YearReleased.ToString() + ", " + Genre + ", " + TimeWatched.ToString();
                    writer.WriteLine(strWhatToWriteToDB);
                    Console.WriteLine(strWhatToWriteToDB + " was saved to the database file.");
                }
                boolSuccesful = true;
            }
            catch
            {
                boolSuccesful = false;
            }

            return boolSuccesful;
        }

        public bool ReadFromDBtextFile()
        {
            bool boolSuccessful = false;

            using (StreamReader reader = new StreamReader(strMovieDiaryFile))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    Console.WriteLine(line); // Use line.
                }
            }

            Console.WriteLine("\r\n");
            return boolSuccessful;
        }
    }//end of class

    //public enum MovieCategory
    //{
    //    Drama,  //0
    //    Comedy, //1
    //    Action, //2
    //    SciFi,  //3
    //    Fiction, //4
    //    Horror   //5
    //}


}
