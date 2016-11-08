using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab10;
using System.Collections;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DisplayMovie()
        {
            Movie testMovie = new Movie("The Last Samurai", "Action");
            string actual = Program.DisplayMovie(testMovie); //run your method here
            string expected = "Title: \"The Last Samurai\"                     Category: Action";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDisplayAllMoviesCatagory()
        {

            ArrayList listOMovies = new ArrayList();

            listOMovies.Add(new Movie("The Last Samurai", "Action"));
            listOMovies.Add(new Movie("The Pink Panther", "Comedy"));
            listOMovies.Add(new Movie("Hacksaw Ridge", "Action"));
            listOMovies.Add(new Movie("Get Smart", "Comedy"));
            listOMovies.Add(new Movie("Oblivion", "Action"));

            string actual = Program.DisplayMoviesSpecificCategory("Action", listOMovies);
            //run your method here ^^^^^





            string expected =
            "Title: \"The Last Samurai\"                     Category: Action\n" +
            "Title: \"Hacksaw Ridge\"                        Category: Action\n" +
            "Title: \"Oblivion\"                             Category: Action\n";
            
            Assert.AreEqual(expected, actual);
        }
    }
}
