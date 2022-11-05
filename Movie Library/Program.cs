using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MovieLibraryEntities.Models;
using MovieLibraryEntities.Context;
using System.Reflection.Metadata;

namespace MovieLibraryEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            int endProgram = 0;
            do
            {
                Console.WriteLine("1: Search for Movie");
                Console.WriteLine("2: Add Movie");
                Console.WriteLine("3: Update Movie");
                Console.WriteLine("4: Delete Movie");
                Console.WriteLine("5: Exit");
                String userChoice = Console.ReadLine();

                // 1. Search for Movie

                if (userChoice == "1")
                {
                    System.Console.WriteLine("Enter Movie Name: ");
                    var inputMovie = Console.ReadLine();

                    using (var db = new MovieContext())
                    {
                        var movie = db.Movies.FirstOrDefault(x => x.Title == inputMovie);
                        Console.WriteLine($"({movie.Id}) {movie.Title}");
                    }
                }

                // 2. Add Movie

                else if (userChoice == "2")
                {
                    System.Console.WriteLine("Enter Movie Name: ");
                    var inputMovie = Console.ReadLine();

                    var movie = new Movie();
                    movie.Title = inputMovie;

                    using (var db = new MovieContext())
                    {
                        db.Add(movie);
                        db.SaveChanges();
                    }
                }

                // 3. Update Movie

                else if (userChoice == "3")
                {
                    System.Console.WriteLine("Enter Movie Name to Update: ");
                    var movieName = Console.ReadLine();

                    System.Console.WriteLine("Enter Updated Movie Name: ");
                    var movieNameUpdate = Console.ReadLine();

                    using (var db = new MovieContext())
                    {
                        var movieUpdate = db.Movies.FirstOrDefault(x => x.Title == movieName);
                        Console.WriteLine($"({movieUpdate.Id}) {movieUpdate.Title}");

                        movieUpdate.Title = movieNameUpdate;

                        db.Movies.Update(movieUpdate);
                        db.SaveChanges();
                    }
                }

                // 4. Delete Movie

                else if (userChoice == "4")
                {
                    System.Console.WriteLine("Enter Movie Name to Delete: ");
                    var movieName = Console.ReadLine();

                    using (var db = new MovieContext())
                    {
                        var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == movieName);
                        Console.WriteLine($"({deleteMovie.Id}) {deleteMovie.Title}");

                        db.Movies.Remove(deleteMovie);
                        db.SaveChanges();
                    }
                }


                else if (userChoice == "5")
                {
                    endProgram = 1;
                }

                else
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (endProgram != 1);







        }
    }
}
