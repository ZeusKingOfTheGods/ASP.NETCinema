﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class MovieModel
    {
        public MovieModel()
        {

        }

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastScreeningDate { get; set; }
        public string MovieType { get; set; }
        public string MovieLenght { get; set; }
        public string ImageString { get; set; }
        public string BannerImageString { get; set; }
        public List<ScreeningModel> Screenings { get; set; }
    }
}
