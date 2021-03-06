﻿using JatoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JatoServices.Abstract
{
    public interface IUserRepository
    {
        bool Login(string userName, string password);
        bool InsertUser(User user);
        User GetUser(int id);
        IQueryable<User> GetUsers();
    }
}
