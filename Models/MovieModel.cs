﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Interfaces;

namespace ASPNETCinema.Models
{
    public class MovieModel : IMovie
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
        public IEnumerable<IScreening> Screenings { get; set; }
    }
}
