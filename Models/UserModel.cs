﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public List<ScreeningModel> Tickets { get; set; }
        public int IdScreening { get; set; }
    }
}
