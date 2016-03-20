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
            return DoOperation(number1, number2, (int)Operations.Operation.Sum, new AddOperation());
        }
         
        [HttpGet]
        [Route("api/UserOperation/Sub")]
        public IHttpActionResult Sub(string number1, string number2)
        {
            return DoOperation(number1, number2, (int)Operations.Operation.Sub, new SubOperation());
        }

        [HttpGet]
        [Route("api/UserOperation/Multiply")]
        public IHttpActionResult Multiply(string number1, string number2)
        {
            return DoOperation(number1, number2, (int)Operations.Operation.Multiply, new MultiplyOperation());
        }

        [HttpGet]
        [Route("api/UserOperation/Divide")]
        public IHttpActionResult Divide(string number1, string number2)
        {
            return DoOperation(number1, number2,(int) Operations.Operation.Divide, new DivideOperation());
        }

        private IHttpActionResult DoOperation(string number1, string number2, int operationType, IOperation operation)
        {

            long num;
            decimal dcml;

            if (long.TryParse(number1, out num))
            {
                var input = new OperationInput<long>() { Num1 = Convert.ToInt64(number1), Num2 = Convert.ToInt64(number2)};
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operationType, input, output);

                return Ok(output.Result);
            }
            else if (Decimal.TryParse(number1, out dcml))
            {
                var input = new OperationInput<decimal>() { Num1 = Convert.ToDecimal(number1), Num2 = Convert.ToDecimal(number2)};
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operationType, input, output);

                return Ok(output.Result);
            }
            else
            {
                var input = new OperationInput<int>() { Num1 = Convert.ToInt32(number1), Num2 = Convert.ToInt32(number2) };
                var output = operation.Do(input);

                _operationHistoryRepository.Save(operationType, input, output);

                return Ok(output.Result);
            }
        }


    }
}
