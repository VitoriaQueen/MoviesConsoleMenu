using Logs;
using Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBFiles
{
    public static class DBFile
    {
        private static readonly string fileName = "movies.csv";
        public static bool WriteToDBtextFile(Movie movie)
        {
            bool boolSuccesful = false;
            var strWhatToWriteToDB = new StringBuilder();

            try
            {
                bool boolDidFileExistAlready = File.Exists(fileName);

                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    if (!boolDidFileExistAlready)
                    {
                        //titulos do arquivo csv
                        strWhatToWriteToDB.Append("Title;");
                        strWhatToWriteToDB.Append("Year;");
                        strWhatToWriteToDB.Append("Genre;");
                        strWhatToWriteToDB.Append("Rating;");
                        strWhatToWriteToDB.AppendLine("TimeWatched");
                        //primeiro registro                      
                        strWhatToWriteToDB.Append(movie.Title + ";");
                        strWhatToWriteToDB.Append(movie.Year + ";");
                        strWhatToWriteToDB.Append(movie.Genre + ";");
                        strWhatToWriteToDB.Append(movie.Rating + ";");
                        strWhatToWriteToDB.Append(movie.TimeWatched.ToShortDateString());
                        writer.WriteLine(strWhatToWriteToDB.ToString());
                    }
                    else
                    {
                        strWhatToWriteToDB.Append(movie.Title + ";");
                        strWhatToWriteToDB.Append(movie.Year + ";");
                        strWhatToWriteToDB.Append(movie.Genre + ";");
                        strWhatToWriteToDB.Append(movie.Rating + ";");
                        strWhatToWriteToDB.AppendLine(movie.TimeWatched.ToShortDateString());
                        writer.WriteLine(strWhatToWriteToDB.ToString());
                    }

                }
                boolSuccesful = true;
            }
            catch (Exception ex)
            {
                Log.WriteToLogFile(ex.Message);
            }

            return boolSuccesful;
        }

        public static List<Movie> ReadFromDBtextFile()
        {
            List<Movie> movies = new List<Movie>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;
                    
                    if (line.Split(';')[0] != "Title")
                        movies.Add(new Movie
                        {
                            Title = line.Split(';')[0],
                            Year = int.Parse(line.Split(';')[1]),
                            Genre = line.Split(';')[2],
                            Rating = int.Parse(line.Split(';')[3]),
                            TimeWatched = DateTime.Parse(line.Split(';')[4])
                        });

                }
            }

            return movies;
        }

    }
}
