using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JatoServices.Common;

namespace JatoServices.Models
{
    public interface IOperationHistoryRepository
    {
        void Save(int operationType, OperationInput<int> input, OperationOutput<int> output);
        void Save(int operationType, OperationInput<decimal> input, OperationOutput<decimal> output);
        void Save(int operationType, OperationInput<long> input, OperationOutput<long> output);
    }

    public class OperationHistoryRepository : IOperationHistoryRepository
    {
        private JATODBEntities _jatodb = new JATODBEntities();

        public void Save(int operationType, OperationInput<int> input, OperationOutput<int> output)
        {
            UserOperations opr = new UserOperations();
            opr.Operation = operationType;
            opr.Result = output.Result.ToString();
            opr.FirstValue = input.Num1.ToString();
            opr.SecondValue = input.Num2.ToString();
            _jatodb.UserOperations.Add(opr);
            _jatodb.SaveChanges();
        }

        public void Save(int operationType, OperationInput<decimal> input, OperationOutput<decimal> output)
        {
            UserOperations opr = new UserOperations();
            opr.Operation = operationType;
            opr.Result = output.Result.ToString();
            opr.FirstValue = input.Num1.ToString();
            opr.SecondValue = input.Num2.ToString();
            _jatodb.UserOperations.Add(opr);
            _jatodb.SaveChanges();
        }

        public void Save(int operationType, OperationInput<long> input, OperationOutput<long> output)
        {
            UserOperations opr = new UserOperations();
            opr.Operation = operationType;
            opr.Result = output.Result.ToString();
            opr.FirstValue = input.Num1.ToString();
            opr.SecondValue = input.Num2.ToString();
            _jatodb.UserOperations.Add(opr);
            _jatodb.SaveChanges();
        }
    }
}