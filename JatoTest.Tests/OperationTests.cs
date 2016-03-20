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
        [TestMethod]
        public void SubOperation_Calculate_Success()
        {

            var operation = new SubOperation();
            var input = new OperationInput<int>() { Num1 = 5, Num2 = 3 };
            var output = operation.Do(input);

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(OperationOutput<int>));
            Assert.AreEqual(((OperationOutput<int>)output).Result, 2);
        }
        [TestMethod]
        public void DivideOperation_Calculate_Success()
        {

            var operation = new DivideOperation();
            var input = new OperationInput<int>() { Num1 = 4, Num2 = 2 };
            var output = operation.Do(input);

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(OperationOutput<int>));
            Assert.AreEqual(((OperationOutput<int>)output).Result, 2);
        }
        [TestMethod]
        public void MultiplyOperation_Calculate_Success()
        {

            var operation = new MultiplyOperation();
            var input = new OperationInput<int>() { Num1 = 3, Num2 = 5 };
            var output = operation.Do(input);

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(OperationOutput<int>));
            Assert.AreEqual(((OperationOutput<int>)output).Result, 15);
        }
    }

    
}
