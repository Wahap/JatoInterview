using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace JatoServices.Models
{
    public class UserMongo
    {

            public ObjectId _id { get; set; }
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
      
    }
}