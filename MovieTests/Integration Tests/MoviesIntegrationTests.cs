using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.DAL;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Movie.MockContext;
using Xunit;

namespace MovieTests
{
    public class MoviesIntegrationTests
    {
        MovieLogic movieLogic;
        IMapper _mapper;
        

        public MoviesIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            movieLogic = new MovieLogic(new MovieRepository(new DatabaseMovie(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }
        
         [Fact]
         public void Should_ReturnTrue_WhenCheckingIfTheGetByIdTestMovieExists()
         {
             //Arrange
             //GetByIdTest Movie is in the database

             //Act
             bool MovieExists = movieLogic.DoesThisMovieExist("Exists");

             //Assert
             Assert.True(MovieExists);
         }

        [Fact]
        public void Should_ReturnFalse_WhenCheckingIfTheMovieExists()
        {
            //Arrange
            //Name is not in database

            //Act
            bool MovieExists = movieLogic.DoesThisMovieExist("RandomTestNameThatsNotInTheDatabase");

            //Assert
            Assert.False(MovieExists);
        }

        [Fact]
        public void Should_ReturnMovie_WhenGettingTheMovieById()
        {
            //Arrange
            //Id = 1010 and Name = 

            //Act
            var Movie = movieLogic.GetMovieById(1010);

            //Assert
            Assert.True(Movie.Id == 1010 && Movie.Name == "GetByIdTest");
        }
    }
}
