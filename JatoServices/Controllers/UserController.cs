using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;
using JatoServices.Common;
using JatoServices.Models;
using Microsoft.Ajax.Utilities;
using JatoServices.Abstract;

namespace JatoServices.Controllers
{
    [EnableCors(origins: "http://localhost:50104", headers: "*", methods: "*")]
    public class UserController : ApiController
    {

        private IUserRepository repository;

        public UserController(IUserRepository _userRepository)
        {
            this.repository = _userRepository;
        }
 
        // GET api/user
        [Route("api/user")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("api/user/Login")]
        public IHttpActionResult Login(string username, string password)
        {

            var user = repository.Login(username, password);
            if (user == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

     

        // GET api/user/5
        [Route("api/user/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var user = repository.GeTUser(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }

        [HttpPost]
        [Route("api/User/RegisterNewMember")]
        public IHttpActionResult RegisterNewMember(User data)
        {
            var user = new User();

            user.Username = data.Username;
            user.Name = data.Name;
            user.Surname = data.Surname;
            user.Password = data.Password;

            bool isSuccessful = repository.InsertUser(user);


          if (isSuccessful == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
          

        }
     
    }
}
