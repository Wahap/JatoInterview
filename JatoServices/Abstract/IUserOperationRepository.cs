using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JatoServices.Abstract
{
    public interface IUserOperationRepository
    {
        string Add(string number1, string number2);
        string Sub(string number1, string number2);
        string Multiply(string number1, string number2);
        string Divide(string number1, string number2);
        void InsertOperations(UserOperations opr);
    }
}