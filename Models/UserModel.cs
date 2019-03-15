﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class UserModel
    {
        public UserModel(int id, string name, string password, int administrator)
        {
            Id = id;
            Name = name;
            Password = password;
            Administrator = administrator;
        }

        public UserModel(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public UserModel()
        {
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Administrator { get; set; }
        public List<ScreeningModel> Tickets { get; set; }




    }
}
