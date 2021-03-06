﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JatoServices.Common;

namespace JatoServices.Models
{
    public class DivideOperation : IOperation
    {

        public OperationOutput<int> Do(OperationInput<int> input)
        {
            var result = input.Num1 / input.Num2;
            return new OperationOutput<int>() { Result = result };
        }

        public OperationOutput<long> Do(OperationInput<long> input)
        {
            var result = input.Num1 / input.Num2;
            return new OperationOutput<long>() { Result = result };
        }

        public OperationOutput<decimal> Do(OperationInput<decimal> input)
        {
            var result = input.Num1 / input.Num2;
            return new OperationOutput<decimal>() { Result = result };
        }
    }
}
