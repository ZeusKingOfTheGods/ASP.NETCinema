﻿using ASPNETCinema.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    internal class HallDto : IHall
    {
        public int Id { get ; set ; }
        public int Seats { get ; set ; }
        public int SeatsTaken { get ; set ; }
        public string ScreenType { get ; set ; }
        public decimal Price { get ; set ; }
        public List<IScreening> Screenings { get; set; }
    }
}