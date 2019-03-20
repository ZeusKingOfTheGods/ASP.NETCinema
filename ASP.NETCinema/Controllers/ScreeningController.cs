﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using DAL;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningContext _screening;

        //added scoped stuff in startup 
        public ScreeningController(IScreeningContext screening)
        {
            _screening = screening;
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public ActionResult ListScreenings()
        {
            var screeningLogic = new ScreeningLogic(_screening);
            List<ScreeningViewModel> screenings = new List<ScreeningViewModel>();
            foreach (var screening in screeningLogic.GetScreenings())
            {
                screenings.Add(new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening
                });
            }
            return View(screenings);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid)
            {
                screeningLogic.AddScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
                return RedirectToAction("ListScreenings");
            }
            return View();
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult DetailsScreening(int id)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid)
            {
                IScreening screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening
                };
                return View(viewScreening);
            }
            return RedirectToAction("ListScreenings");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(int id)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid)
            {
                IScreening screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening
                };
                return View(viewScreening);
            }
            return RedirectToAction("ListScreenings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid && screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening))
            {
                screeningLogic.EditScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
                return RedirectToAction("ListScreenings");
            }
            else
            {
                ViewBag.HasError = true;
                ViewBag.ErrorMessage = "This Hall already has a screening on this day and time!";
            }

            return View();
        }

        public ActionResult DeleteScreening(int id)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid)
            {
                IScreening screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening
                };
                return View(viewScreening);
            }
            return RedirectToAction("ListScreenings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteScreening(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            screeningLogic.DeleteScreening(screening.Id);
            return RedirectToAction("ListScreenings");
        }


    }
}