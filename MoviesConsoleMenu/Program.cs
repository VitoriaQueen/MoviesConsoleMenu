using DBFiles;
using Logs;
using Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMovies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu();

                Console.ReadKey();
            }
            catch (Exception exc)
            {
                Log.WriteToLogFile(exc.Message);
            }
        }

        static void Menu()
        {
            bool boolExit = false;

            while (!boolExit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("**********************************");
                    Console.WriteLine("* Welcome to the Movie Database. *");
                    Console.WriteLine("**********************************");
                    Console.WriteLine("Please make your selection from the menu as follows:");
                    Console.WriteLine("1. Enter Movie watched.");
                    Console.WriteLine("2. Search for movie.");
                    Console.WriteLine("3. Show listing of movies watched.");
                    Console.WriteLine("4. Exit this menu.");
                    Console.WriteLine("**********************************");
                    string strSelectedNumber = Console.ReadLine();


                    bool boolResult = int.TryParse(strSelectedNumber, out int intSelectedNumber);
                    if ((intSelectedNumber > 0) && (intSelectedNumber < 5))
                    {
                        //string strTemp = "";
                        boolResult = false;

                        switch (intSelectedNumber)
                        {
                            case 1:
                                boolResult = CreateMovie();
                                if (boolResult == true)
                                {
                                    Console.WriteLine("Movie updated successfully\r\n\r\n");
                                }
                                else
                                {
                                    Console.WriteLine("Movie failed to update");
                                }
                                break;
                            case 2:
                                var movies = SearchMovie();
                                if (movies.Any())
                                {
                                    ListMovies(movies);
                                }
                                else
                                {
                                    Console.WriteLine("Movie nao encontrado");
                                }
                                break;
                            case 3:
                                var moviesBusca = DBFile.ReadFromDBtextFile();
                                ListMovies(moviesBusca);
                                break;
                            case 4:
                                boolExit = true;
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please select a number between 1 to 4 for the menu items.");
                    }
                }
                catch (Exception exc)
                {
                    Log.WriteToLogFile(exc.Message);
                }

            }

            Console.WriteLine("Press ENTER key to exit");
        }

        private static bool CreateMovie()
        {
            bool boolResult = false;
            var movie = new Movie { };

            Console.WriteLine("What is the name of the movie.");
            movie.Title = Console.ReadLine();

            string strTemp;
            while (!boolResult)
            {
                Console.WriteLine("What was the year that the movie released?");
                strTemp = Console.ReadLine();
                boolResult = int.TryParse(strTemp, out int year);

                if (boolResult)
                {
                    movie.Year = year;
                }
                else
                {
                    Console.WriteLine("Invalid year typed.");
                }
            }

            Console.WriteLine("What is the Genre of the movie? Enter either Drama, Comedy, Action, SciFi, Fiction, or Horror.");
            movie.Genre = Console.ReadLine();

            boolResult = false;
            while (!boolResult)
            {
                Console.WriteLine("When did you last watch this movie? \r\nPlease enter the time and date in this format: mm/dd/yyyy\r\nFor example: 2/2/2000");
                strTemp = Console.ReadLine();

                boolResult = DateTime.TryParse(strTemp, out DateTime dt);
                if (boolResult)
                {
                    movie.TimeWatched = dt;
                    Console.WriteLine("The last time you watched this movie, that will be saved to the DB file, is: " + dt.ToShortDateString());
                }
                else
                {
                    Console.WriteLine("Invalid year typed.");
                }
            }

            return DBFile.WriteToDBtextFile(movie);
        }

        private static List<Movie> SearchMovie()
        {
            try
            {
                Console.WriteLine("Enter the movie that you want to search the Movie Diary DB for.");
                string strMovieToSearchFor = Console.ReadLine();
                List<Movie> listMovies = DBFile.ReadFromDBtextFile();

                //usando linq para a busca
                //aqui to usando para buscar pelo titulo, genero, ano 
                var movies = listMovies.Where(m =>
                    m.Title.ToLower().Contains(strMovieToSearchFor.ToLower()) ||
                    m.Genre.ToLower().Contains(strMovieToSearchFor.ToLower()) ||
                    m.Year.ToString().Contains(strMovieToSearchFor) ||
                    m.TimeWatched.ToString().Contains(strMovieToSearchFor)
                ).ToList();

                return movies;
            }
            catch (Exception exc)
            {
                Log.WriteToLogFile(exc.Message);
            }

            return new List<Movie> { };
        }

        private static void ListMovies(List<Movie> movies)
        {
            try
            {
                var movieLine = new StringBuilder();
                movieLine.Append("Title\t\t");
                movieLine.Append("Genre\t");
                movieLine.Append("Year\t");
                movieLine.AppendLine("TimeWatched\n");

                Console.WriteLine(movieLine.ToString());

                movies.ForEach(movie =>
                {
                    movieLine.Clear();
                    movieLine.Append($"{movie.Title}\t");
                    movieLine.Append($"{movie.Genre}\t");
                    movieLine.Append($"{movie.Year}\t");
                    movieLine.AppendLine($"{movie.TimeWatched.ToShortDateString()}\t\t");
                    Console.WriteLine(movieLine.ToString());

                });
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Log.WriteToLogFile(ex.Message);
            }
        }
    }
}

