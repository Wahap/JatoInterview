using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Antlr.Runtime;
using JatoServices.Abstract;
using JatoServices.Common;
using JatoServices.Concrete;

namespace JatoServices.Models
{

    public class UserRepository : IUserRepository
    {
        

        private static JATODBEntities _jatodb = new JATODBEntities();
        private static MongoDBEntities _Mongodb;

        public bool Login(string userName, string password)
        {
            var user = from usr in _jatodb.User
                       where usr.Password == password && usr.Username == userName
                       select usr;


            if (user.Count() != 0)
            {
                return true;

            }
            return false;
        }

        public bool InsertUser(User user)
        {
            _Mongodb = new MongoDBEntities();
            try
            {
                _jatodb.User.Add(user);
                _jatodb.SaveChanges();
                _Mongodb.CreateUser(user);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }


        public IQueryable<User> GetUsers()
        {
            var query = from user in _jatodb.User
                        select user;

            return query.AsQueryable();
        }


        public User GetUser(int id)
        {
            var query = from user in _jatodb.User
                        where user.Id == id
                        select user;

            return query.SingleOrDefault();
        }
    }
}