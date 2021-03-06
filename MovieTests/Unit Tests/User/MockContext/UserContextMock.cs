﻿using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using static aMVCLayer.Enums.UserType;
using UserDto = DAL.Dtos.UserDto;

namespace UnitTests.User.MockContext
{
    class UserContextMock : IUserContext
    {
        List<UserDto> users = new List<UserDto>();
        List<UserDto> usersTemp = new List<UserDto>();
        List<UserDto> usersTempDeleted = new List<UserDto>();
        int delete = 0;
        int edit = 0;
        string editName = "";

        public List<UserDto> GetUsers()
        {
            users.Clear();
            SetUsers();
            AddedUsers();
            return users;
        }

        public void SetUsers()
        {
            users.Add(new UserDto
            {
                Id = 1,
                Name = "Normal",
                Password = SecurePasswordHasher.Hash("IdOne"),
                Role = UserTypes.Normal.ToString()
            });

            users.Add(new UserDto
            {
                Id = 5,
                Name = "Employee",
                Password = SecurePasswordHasher.Hash("IdFive"),
                Role = UserTypes.Employee.ToString()
            });

            users.Add(new UserDto
            {
                Id = 2,
                Name = "NormalTwo",
                Password = SecurePasswordHasher.Hash("IdTwo"),
                Role = UserTypes.Normal.ToString()
            });

            users.Add(new UserDto
            {
                Id = 3,
                Name = "Admin",
                Password = SecurePasswordHasher.Hash("IdThree"),
                Role = UserTypes.Administrator.ToString()
            });

            WasSomethingDeleted();
            WasSomethingEdited();
        }

        public void WasSomethingDeleted()
        {
            if (delete != 0)
            {
                foreach (var user in users)
                {
                    if (user.Id == delete)
                    {
                        users.Remove(user);
                        break;
                    }
                }
            }
        }

        public void WasSomethingEdited()
        {
            if (edit != 0)
            {
                foreach (var user in users)
                {
                    if (user.Id == edit && editName != "")
                    {
                        users[0].Name = editName;
                        break;
                    }
                }
            }
        }

        public void AddUser(UserModel user)
        {
            usersTemp.Add(new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role
            });
        }

        private void AddedUsers()
        {
            foreach (var user in usersTemp)
            {
                users.Add(user);
            }
        }

        public void EditUser(UserModel user)
        {
            edit = user.Id;
            editName = user.Name;
        }

        public void DeleteUser(int id)
        {
            delete = id;
        }

        public UserDto GetUser(string name, string password)
        {
            foreach (var user in users)
            {
                if (user.Name == name && SecurePasswordHasher.Verify(password, user.Password) == true)
                {
                    return user;
                }
            }
            return null;
        }

        public string GetUserRole(int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user.Role;
                }
            }
            foreach (var user in usersTemp)
            {
                if (user.Id == id)
                {
                    return user.Role;
                }
            }
            return "Null";
        }

        public UserDto DoesThisUserExist(string name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }
            foreach (var user in usersTemp)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
