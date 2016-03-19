using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace JatoServices.Models
{

        public class MongoDBEntities : DbContext
        {
            public MongoDBEntities() : base("name=MongoConnection") { }
            static MongoServer server = MongoServer.Create(ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString.ToString());
            MongoDatabase database = server.GetDatabase("JatoMongo");


            #region user
            List<User> User;
            public List<User> Users
            {
                get
                {
                    var collection = database.GetCollection<User>("User");
                    return collection.FindAllAs<User>().ToList();
                }
                set { User = value; }
            }
            public void CreateUser(User colleciton)
            {
                try
                {
                    int Id = 0;
                    if (Users.Any())
                        Id = Users.Max(x => x.Id);
                    Id += 1;
                    MongoCollection<User> MCollection = database.GetCollection<User>("User");
                    BsonDocument doc = new BsonDocument { 
                    {"Id",colleciton.Id},
                    {"Name",colleciton.Name},
                    {"Password",colleciton.Password},
                    {"Surname",colleciton.Surname},
                    {"Username",colleciton.Username}
                };

                    IMongoQuery query = Query.EQ("Id", colleciton.Id);
                    var exists = MCollection.Find(query);
                    if (exists.ToList().Count == 0)
                        MCollection.Insert(doc);

                }
                catch { }
            }
      
            #endregion


            #region Operations

            List<UserOperations> userOper;
            public List<UserOperations> UOperations
            {
                get
                {
                    var collection = database.GetCollection<UserOperations>("UserOperations");
                    return collection.FindAllAs<UserOperations>().ToList();
                }
                set { userOper = value; }
            }
            public void CreateUserOperaions(UserOperations colleciton)
            {
                try
                {
                    int Id = 0;
                    if (UOperations.Any())
                        Id = UOperations.Max(x => x.Id);
                    Id += 1;
                    MongoCollection<UserOperations> MCollection = database.GetCollection<UserOperations>("UserOperations");
                    BsonDocument doc = new BsonDocument { 
                    {"Id",Id},
                    {"Operation",colleciton.Operation},
                    {"Result",colleciton.Result},
                    {"FirstValue",colleciton.FirstValue},
                    {"SecondValue",colleciton.SecondValue}
                };

                    IMongoQuery query = Query.EQ("Id", colleciton.Id);
                    var exists = MCollection.Find(query);
                    if (exists.ToList().Count == 0)
                        MCollection.Insert(doc);

                }
                catch { }
            }

            #endregion
        }
    }