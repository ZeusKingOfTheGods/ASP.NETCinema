﻿using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Repository;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class HallLogic
    {
        private HallRepository Repository { get; }

        public HallLogic(IHallContext context)
        {
            Repository = new HallRepository(context);
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        public HallLogic()
        {
        }

        public IHall GetHallById(int id)
        {
            return Repository.GetHallById(id);
        }

        public IEnumerable<IHall> GetHalls()
        {
            return Repository.GetHalls();
        }

        public void AddHall(int id, decimal price, string screenType, int seats, int seatsTaken)
        {
            var hall = new HallModel
            {
                Id = id,
                Price = price,
                ScreenType = screenType,
                Seats = seats,
                SeatsTaken = seatsTaken
            };
            Repository.AddHall(hall);
        }

        public void EditHall(int id, decimal price, string screenType, int seats, int seatsTaken)
        {
            var hall = new HallModel
            {
                Id = id,
                Price = price,
                ScreenType = screenType,
                Seats = seats,
                SeatsTaken = seatsTaken
            };
            Repository.EditHall(hall);
        }

        public void DeleteHall(int id)
        {
            Repository.DeleteHall(id);
        }


    }
}