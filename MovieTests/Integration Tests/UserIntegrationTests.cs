﻿using ASPNETCinema;
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


namespace UserTests
{
    public class UserIntegrationTests
    {
        UserLogic userLogic;
        IMapper _mapper;

        public UserIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            userLogic = new UserLogic(new UserRepository(new DatabaseUser(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }

        [Fact]
        public void Should_ReturnAnUser_WhenGettingAUserById()
        {
            //Arrange
            //Id = 1012 and Name = Admin

            //Act
            var exists = userLogic.DoesThisUserExist("Admin");

            //Assert
            Assert.True(exists);
        }

        [Fact]
        public void Should_ReturnNull_WhenGettingAUserByIdThatDoesntExist()
        {
            //Arrange
            //Not in DB

            //Act
            var exists = userLogic.DoesThisUserExist("ThisNameIsNotInTheDB");

            //Assert
            Assert.False(exists);
        }
    }
}
