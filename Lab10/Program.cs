using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab10
{
    public class Program
    {
        static string input = "";
        static ArrayList listOfAllMovies;


        static void Main(string[] args)
        {
            do
            {
                //Output
                Console.WriteLine("Welcome to the Movie List Application!");
                Console.WriteLine();
                Console.WriteLine("There are " + ListOfMovies().Count + " movies in this list.");
                Console.WriteLine("What category are you interested in?");
                //Input
                Console.Write("Input: ");

                input = ValidateInput();

                if (input.ToLower() == "all")
                {
                    //Output again.
                    Console.WriteLine(DisplayAllMovies());
                }
                else
                {
                    //More Output
                    Console.WriteLine("Here are all of the movies with the selected catagory");

                    //Output/Processing ----------- displays all valid categories
                    Console.WriteLine(DisplayMoviesSpecificCategory(input));
                }
                //checking if they want to contine.
                Console.Write("Restart Program? (y/n): ");
            } while (CheckYesNo());

        }

        //private static string ValidateInput(ArrayList listOfAllMovies)
        //{
        //    string input;
        //    while (true)
        //    {
        //        input = Console.ReadLine();
        //        if (GetListOfCategories(listOfAllMovies).Contains(input)) break;
        //        else if (input.ToLower() == "all")
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("I'm sorry, that is not a valid category, valid categories are:");
        //            foreach (string category in (GetListOfCategories(listOfAllMovies)))
        //            {
        //                Console.WriteLine(category);
        //            }
        //        }

        //    }

        //    return input;
        //}

        private static string ValidateInput()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (GetListOfCategories().Contains(input)) break;
                else if (input.ToLower() == "all")
                {
                    break;
                }
                else if (input.ToLower() == "movie")
                {
                    Movie movie;
                    Console.Write("Input Movie Title: ");
                    CheckForMovie(Console.ReadLine(), out movie);

                    if (!(movie == null))
                    {
                        Console.WriteLine(DisplayMovie(movie));
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, the movie you asked for does not exist in the database.");
                        Console.Write("Press any key to display all of the movies.");
                        Console.ReadKey();
                        return "all";

                    }
                }
                else
                {
                    Console.WriteLine("I'm sorry, that is not a valid category, valid categories are:");
                    foreach (string category in (GetListOfCategories()))
                    {
                        Console.WriteLine(category);
                    }
                    Console.WriteLine("Or type \"All\" for a list of all the movies.");
                    Console.WriteLine("Or type \"Movie\" to search for a specific movie name.");
                }

            }

            return input;
        }

        private static bool CheckForMovie(string title, out Movie movie)
        {
            foreach (Movie mv in listOfAllMovies)
            {
                if (mv.Title == title)
                {
                    movie = mv;
                    return true;
                }
            }
            movie = null;
            return false;
        }

        //private static string DisplayAllMovies(ArrayList listOfAllMovies)
        //{
        //    string displayedMoviesString = "";

        //    foreach (string category in (GetListOfCategories(listOfAllMovies)))
        //    {
        //        foreach (Movie movie in GetMoviesSpecificCategory(category, listOfAllMovies))
        //        {

        //            displayedMoviesString += (DisplayMovie(movie)) + "\n";
        //        }
        //    }

        //    return displayedMoviesString;
        //}
        private static string DisplayAllMovies()
        {
            string displayedMoviesString = "";

            foreach (string category in GetListOfCategories())
            {
                foreach (Movie movie in GetMoviesSpecificCategory(category))
                {

                    displayedMoviesString += (DisplayMovie(movie)) + "\n";
                }
            }

            return displayedMoviesString;
        }

        private static bool CheckYesNo()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input[0].ToString().ToLower() == "n")
                {
                    return false;
                }
                else if (input[0].ToString().ToLower() == "y")
                {
                    Console.Clear();
                    return true;
                }
                Console.Write("Invalid input, please try again: ");
            }
        }
        

        //public static List<string> GetListOfCategories(ArrayList list)
        //{
        //    List<string> listOfCatagories = new List<string>();

        //    foreach (Movie movie in list)
        //    {
        //        if (!(listOfCatagories.Contains(movie.Category.ToString().ToLower())))
        //        {
        //            listOfCatagories.Add(movie.Category.ToLower());
        //        }
        //    }
        //    return listOfCatagories;
        //}
        public static List<string> GetListOfCategories()
        {
            List<string> listOfCatagories = new List<string>();

            foreach (Movie movie in ListOfMovies())
            {
                if (!(listOfCatagories.Contains(movie.Category.ToString().ToLower())))
                {
                    listOfCatagories.Add(movie.Category.ToLower());
                }
            }
            return listOfCatagories;
        }

        //public static void PopulateListOfMovies(ArrayList ListOfMovies)
        //{
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        ListOfMovies.Add(MovieIO.getMovie(i));
        //    }
        //}
        //This adds every single movie from the MovieIO class and returns a new list.
        public static List<Movie> ListOfMovies()
        {
            List<Movie> returnList = new List<Movie>();
            for (int i = 1; i <= 100; i++)
            {
                returnList.Add(MovieIO.getMovie(i));
            }
            return returnList;
        }

        public static void PopulateHashOfMoviesCategories(Hashtable HashListOfMovies)
        {
            foreach(string category in GetListOfCategories())
            {
                HashListOfMovies.Add(category, GetMoviesSpecificCategory(category));
            }
        }

        //This method returns one long string with new line marks
        public static string DisplayMoviesSpecificCategory(string Category, ArrayList list)
        {
            string displayedMoviesString = "";
            foreach (Movie movie in GetMoviesSpecificCategory(Category, list))
            {
                displayedMoviesString += (DisplayMovie(movie)) + "\n";
            }
            return displayedMoviesString;
        }
        public static string DisplayMoviesSpecificCategory(string Category)
        {
            string displayedMoviesString = "";
            foreach (Movie movie in GetMoviesSpecificCategory(Category))
            {
                displayedMoviesString += (DisplayMovie(movie)) + "\n";
            }
            return displayedMoviesString;
        }
        public static string DisplayMoviesInList(List<Movie> list)
        {
            string displayedMoviesString = "";
            foreach (Movie movie in list)
            {
                displayedMoviesString += (DisplayMovie(movie)) + "\n";
            }
            return displayedMoviesString;
        }


        public static List<Movie> GetMoviesSpecificCategory(string Category, ArrayList list)
        {
            List<Movie> returnList = new List<Movie>();
            foreach (Movie movie in list)
            {
                if (movie.Category == Category)
                {
                    returnList.Add(movie);
                }
            }
            return returnList;
        }
        public static List<Movie> GetMoviesSpecificCategory(string Category)
        {
            List<Movie> returnList = new List<Movie>();
            foreach (Movie movie in ListOfMovies())
            {
                if (movie.Category == Category)
                {
                    returnList.Add(movie);
                }
            }
            return returnList;
        }


       

        public static string DisplayMovie(Movie movie)
        {
            return (("Title: " + (('"' + movie.Title + '"').PadRight(39)) + ("Category: " + movie.Category)));
        }


    }
}
