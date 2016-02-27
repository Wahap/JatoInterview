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

namespace JatoServices.Controllers
{
    [EnableCors(origins: "http://localhost:50104", headers: "*", methods: "*")]
    public class UserController : ApiController
    {

        
 
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

            var user = UserRepository.Login(username, password);
            if (user == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        [Route("api/user/Sum")]
        public string Sum(string number1, string number2)
            {
            string result = UserRepository.Add(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int) Operations.Operation.Sum;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            UserRepository.InsertOperations(opr);
            return result.ToString();
        }
         [HttpGet]
        [Route("api/user/Sub")]
        public string Sub(string number1, string number2)
        {
            string result = UserRepository.Sub(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Sub;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            UserRepository.InsertOperations(opr);
            return result.ToString();
        }
         [HttpGet]
        [Route("api/user/Multiply")]
        public string Multiply(string number1, string number2)
        {
            string result = UserRepository.Multiply(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Multiply;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            UserRepository.InsertOperations(opr);
            return result.ToString();
        }
         [HttpGet]
        [Route("api/user/Divide")]
        public string Divide(string number1, string number2)
        {
            string result = UserRepository.Divide(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Divide;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            UserRepository.InsertOperations(opr);
            return result.ToString();
        }


        // GET api/user/5
        [Route("api/user/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var user = UserRepository.GeTUser(id);
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

          bool isSuccessful=  UserRepository.InsertUser(user);


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
