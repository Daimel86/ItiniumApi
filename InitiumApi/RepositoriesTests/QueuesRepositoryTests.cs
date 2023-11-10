using Domain.Context;
using Domain.Context.Contracts;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories;

namespace RepositoriesTests
{
    [TestClass]
    public class QueuesRepositoryTests
    {
        [TestMethod]
        public void GetQueuesAsync_ShouldRemoveClients()
        {
            var context = new Mock<IInitiumDbContext>();

            var repository = new QueuesRepository((context.Object as InitiumDbContext)!);

            var queue = new List<QueuesEntity> {
                new QueuesEntity() {
                    Clients = new List<ClientsEntity> { 
                        new ClientsEntity {
                            ClientName = "Pepe",
                            Id = 1,
                            QueueId = 1,
                            RegistrationDate = DateTime.UtcNow.AddMinutes(-5),
                    } },
                    DurationMinutes = 2,
                    Id = 1,
                    QueueName="name 1"
                }
            };

            var response = repository.ProcessQueue(queue);

            Assert.IsTrue(response.Any());
            Assert.AreEqual(queue.SelectMany(s => s.Clients!).Count(), 0);
        }
    }
}
