using Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories.Contracts;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class QueuesControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var logger = new Mock<ILogger<QueuesController>>();
            var repository = new Mock<IQueuesRepository>();
            repository.Setup(s => s.GetQueuesAsync()).ReturnsAsync(() => new List<QueuesEntity>() { new QueuesEntity() });

            var controller = new QueuesController(logger.Object, repository.Object);
            var response = controller.Get().GetAwaiter().GetResult();

            repository.Verify(v => v.GetQueuesAsync(), Times.Once);
            Assert.AreEqual(response.Count(), 1);
        }
    }
}