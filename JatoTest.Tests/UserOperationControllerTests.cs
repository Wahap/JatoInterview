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

            _operationHistoryRepository.Verify(s => s.Save(It.IsAny<string>(), It.IsAny<OperationInput<long>>(), It.IsAny<OperationOutput<long>>()));
        }
    }
}
