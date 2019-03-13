using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieTests
{
    public class GettingMoviesTest
    {
        MovieLogic movieLogic = new MovieLogic();
        MovieController movieController = new MovieController();
        List<MovieModel> movies = new List<MovieModel>();
        List<MovieModel> movies2 = new List<MovieModel>();
        ThingEqualityComparer comparer = new ThingEqualityComparer();


        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingMoviesByName()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("Name");
            movies2 = movieLogic.GetMoviesAndOrderBy("Name");

            bool found = false;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {

                    if (movie.Id == movie2.Id && movieNr == movie2Nr)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                    movie2Nr++;
                }
                if (found == false)
                {
                    Assert.True(false);
                }
                movieNr++;
            }
        }

        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingMoviesByNull()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy(null);
            movies2 = movieLogic.GetMoviesAndOrderBy(null);

            bool found = false;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {

                    if (movie.Id == movie2.Id && movieNr == movie2Nr)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                    movie2Nr++;
                }
                if (found == false)
                {
                    Assert.True(false);
                }
                movieNr++;
            }
        }


        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingMoviesByToday()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("MoviesToday");
            movies2 = movieLogic.GetMoviesAndOrderBy("MoviesToday");

            bool found = false;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {
                    
                    if (movie.Id == movie2.Id && movieNr == movie2Nr)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                    movie2Nr++;
                }
                if (found == false)
                {
                    Assert.True(false);
                }
                movieNr++;
            }
        }

        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingMoviesByReleaseAndName()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("ReleaseDate");
            movies2 = movieLogic.GetMoviesAndOrderBy("Name");

            bool found = false;
            bool diffOrder = false;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (movie.Id == movie2.Id && movieNr == movie2Nr && diffOrder == false && movies.Count > 4)
                    {
                        Assert.False(comparer.Equals(movie, movie2) == diffOrder);
                        found = true;
                    }
                    else if (movie.Id == movie2.Id)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                        diffOrder = true;
                    }
                    movie2Nr++;
                }

                if (found == false)
                {
                    Assert.True(false);
                }
                movieNr++;
            }
        }



        class ThingEqualityComparer : IEqualityComparer<MovieModel>
        {
            public bool Equals(MovieModel x, MovieModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name);
            }

            public int GetHashCode(MovieModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
