﻿using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using Repository;

namespace Interfaces.Outside_interfaces
{
    public class EmployeeLogic
    {
        DatabaseEmployee database = new DatabaseEmployee();
        private EmployeeRepository Repository { get; }

        public EmployeeLogic(IEmployeeContext context)
        {
            Repository = new EmployeeRepository(context);
        }

        public string GetName(int id)
        {
            return "test " + id;
        }
        /*public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach (var employee in database.GetEmployees())
            {
                employees.Add(new EmployeeModel { Name = employee.Name, Id = employee.Id });
            }
            
            return employees;
        }
        */

        public IEnumerable<IEmployee> GetEmployees()
        {
            return Repository.GetEmployees();
        }
    }
}
