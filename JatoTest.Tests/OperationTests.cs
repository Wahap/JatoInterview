using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JatoServices.Models;
using Moq;

namespace JatoTest.Tests
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void AddOperation_Calculate_Success()
        {

            var operation = new AddOperation();
            var input = new OperationInput<int>() { Num1 = 1, Num2 = 3};
            var output = operation.Do(input);

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(OperationOutput<int>));
            Assert.AreEqual(((OperationOutput<int>)output).Result, 4);
        }
    }

    
}
