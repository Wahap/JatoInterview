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
        
        private IOperationHistoryRepository _operationHistoryRepository;

        public UserOperationController( IOperationHistoryRepository operationHistoryRepository)
        {
           
            this._operationHistoryRepository = operationHistoryRepository;
        }

        [HttpGet]
        [Route("api/UserOperation/Sum")]
        public IHttpActionResult Sum(string number1, string number2)
        {
            return DoOperation(number1, number2, new AddOperation());
        }
         
        [HttpGet]
        [Route("api/UserOperation/Sub")]
        public IHttpActionResult Sub(string number1, string number2)
        {
            return DoOperation(number1, number2, new SubOperation());
        }

        [HttpGet]
        [Route("api/UserOperation/Multiply")]
        public IHttpActionResult Multiply(string number1, string number2)
        {
            return DoOperation(number1, number2, new MultiplyOperation());
        }

        [HttpGet]
        [Route("api/UserOperation/Divide")]
        public IHttpActionResult Divide(string number1, string number2)
        {
            return DoOperation(number1, number2, new DivideOperation());
        }

        private IHttpActionResult DoOperation(string number1, string number2, IOperation operation)
        {
            long num;
            decimal dcml;

            if (long.TryParse(number1, out num))
            {
                var input = new OperationInput<long>() {Num1 = Convert.ToInt64(number1), Num2 = Convert.ToInt64(number2)};
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operation.GetType().Name, input, output);

                return Ok(output.Result);
            }
            else if (Decimal.TryParse(number1, out dcml))
            {
                var input = new OperationInput<decimal>() {Num1 = Convert.ToDecimal(number1), Num2 = Convert.ToDecimal(number2)};
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operation.GetType().Name, input, output);

                return Ok(output.Result);
            }
            else
            {
                var input = new OperationInput<int>() {Num1 = Convert.ToInt32(number1), Num2 = Convert.ToInt32(number2)};
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operation.GetType().Name, input, output);

                return Ok(output.Result);
            }
        }

        //[HttpGet]
        //[Route("api/UserOperation/Sub")]
        //public string Sub(string number1, string number2)
        //{
        //    string result = operationRepository.Sub(number1, number2);
        //    UserOperations opr = new UserOperations();
        //    opr.Operation = (int)Operations.Operation.Sub;
        //    opr.Result = result;
        //    opr.FirstValue = number1;
        //    opr.SecondValue = number2;
        //    operationRepository.InsertOperations(opr);
        //    return result.ToString();
        //}
        //[HttpGet]
        //[Route("api/UserOperation/Multiply")]
        //public string Multiply(string number1, string number2)
        //{
        //    string result = operationRepository.Multiply(number1, number2);
        //    UserOperations opr = new UserOperations();
        //    opr.Operation = (int)Operations.Operation.Multiply;
        //    opr.Result = result;
        //    opr.FirstValue = number1;
        //    opr.SecondValue = number2;
        //    operationRepository.InsertOperations(opr);
        //    return result.ToString();
        //}
        //[HttpGet]
        //[Route("api/UserOperation/Divide")]
        //public string Divide(string number1, string number2)
        //{
        //    string result = operationRepository.Divide(number1, number2);
        //    UserOperations opr = new UserOperations();
        //    opr.Operation = (int)Operations.Operation.Divide;
        //    opr.Result = result;
        //    opr.FirstValue = number1;
        //    opr.SecondValue = number2;
        //    operationRepository.InsertOperations(opr);
        //    return result.ToString();
        //}

    }
}
