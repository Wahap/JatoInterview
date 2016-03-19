using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using JatoServices.Abstract;
using JatoServices.Common;
using JatoServices.Models;

namespace JatoServices.Controllers
{
    [EnableCors(origins: "http://localhost:50104", headers: "*", methods: "*")]
    public class UserOperationController : ApiController
    {
        private IUserOperationRepository operationRepository;

        public UserOperationController(IUserOperationRepository _operationRepository)
        {
            this.operationRepository = _operationRepository;
        }

        [HttpGet]
        [Route("api/UserOperation/Sum")]
        public string Sum(string number1, string number2)
        {
            string result = operationRepository.Add(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Sum;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            operationRepository.InsertOperations(opr);
            return result.ToString();
        }
        [HttpGet]
        [Route("api/UserOperation/Sub")]
        public string Sub(string number1, string number2)
        {
            string result = operationRepository.Sub(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Sub;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            operationRepository.InsertOperations(opr);
            return result.ToString();
        }
        [HttpGet]
        [Route("api/UserOperation/Multiply")]
        public string Multiply(string number1, string number2)
        {
            string result = operationRepository.Multiply(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Multiply;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            operationRepository.InsertOperations(opr);
            return result.ToString();
        }
        [HttpGet]
        [Route("api/UserOperation/Divide")]
        public string Divide(string number1, string number2)
        {
            string result = operationRepository.Divide(number1, number2);
            UserOperations opr = new UserOperations();
            opr.Operation = (int)Operations.Operation.Divide;
            opr.Result = result;
            opr.FirstValue = number1;
            opr.SecondValue = number2;
            operationRepository.InsertOperations(opr);
            return result.ToString();
        }

    }
}
