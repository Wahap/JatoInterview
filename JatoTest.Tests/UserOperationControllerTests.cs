using System;
using System.Web.Http.Results;
using JatoServices.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JatoServices.Models;

namespace JatoTest.Tests
{
    [TestClass]
    public class UserOperationControllerTests
    {
        private Mock<IOperationHistoryRepository> _operationHistoryRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _operationHistoryRepository = new Mock<IOperationHistoryRepository>();
        }

        [TestMethod]
        public void UserOperationController_Sum_Success()
        {
            var controller = new UserOperationController(_operationHistoryRepository.Object);
            var result = controller.Sum("3", "5");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<long>));
            Assert.AreEqual(((OkNegotiatedContentResult<long>)result).Content, 8);

            _operationHistoryRepository.Verify(s => s.Save(It.IsAny<int>(), It.IsAny<OperationInput<long>>(), It.IsAny<OperationOutput<long>>()));
        }
        [TestMethod]
        public void UserOperationController_Sub_Success()
        {
            var controller = new UserOperationController(_operationHistoryRepository.Object);
            var result = controller.Sub("5", "3");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<long>));
            Assert.AreEqual(((OkNegotiatedContentResult<long>)result).Content, 2);

            _operationHistoryRepository.Verify(s => s.Save(It.IsAny<int>(), It.IsAny<OperationInput<long>>(), It.IsAny<OperationOutput<long>>()));
        }
        [TestMethod]
        public void UserOperationController_Multiply_Success()
        {
            var controller = new UserOperationController(_operationHistoryRepository.Object);
            var result = controller.Multiply("3", "5");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<long>));
            Assert.AreEqual(((OkNegotiatedContentResult<long>)result).Content, 15);

            _operationHistoryRepository.Verify(s => s.Save(It.IsAny<int>(), It.IsAny<OperationInput<long>>(), It.IsAny<OperationOutput<long>>()));
        }
        [TestMethod]
        public void UserOperationController_Divide_Success()
        {
            var controller = new UserOperationController(_operationHistoryRepository.Object);
            var result = controller.Divide("6", "2");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<long>));
            Assert.AreEqual(((OkNegotiatedContentResult<long>)result).Content, 3);

            _operationHistoryRepository.Verify(s => s.Save(It.IsAny<int>(), It.IsAny<OperationInput<long>>(), It.IsAny<OperationOutput<long>>()));
        }
    }
}
