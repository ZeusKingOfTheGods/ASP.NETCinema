﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using Interfaces;
using Interfaces.Outside_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLogic employeeLogic = new EmployeeLogic();

        public ActionResult ListEmployees()
        {
            IEmployee employee = new Employee();
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach (var emp in employee.GetEmployees())
            {
                employees.Add(new EmployeeViewModel
                {
                    Id = emp.Id,
                    Name = emp.Name
                });
            }
            //List<EmployeeModel> employees = employee.GetEmployees();
            return View(employees);
            //test


            //return View(employeeLogic.GetEmployees());
        }

        public ActionResult DetailsEmployee()
        {
            IEmployee employee = new Employee();
            ViewBag.employeeName = employee.GetName(1);
            return View();
        }

    }
}