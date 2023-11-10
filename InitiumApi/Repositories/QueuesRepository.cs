using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class QueuesRepository : IQueuesRepository
{
    private readonly InitiumDbContext _initiumDbContext;

    public QueuesRepository(InitiumDbContext initiumDbContext) => _initiumDbContext = initiumDbContext;

    public async Task<IEnumerable<QueuesEntity>> GetQueuesAsync()
    {
        var transaction = await _initiumDbContext.Database.BeginTransactionAsync();
        try
        {
            var queues = await _initiumDbContext.Queues.Include(i => i.Clients).ToListAsync();
            var clientsToRemove = ProcessQueue(queues);

            _initiumDbContext.RemoveRange(clientsToRemove);
            await _initiumDbContext.SaveChangesAsync();

            await transaction.CommitAsync();
            return queues;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public List<ClientsEntity> ProcessQueue(List<QueuesEntity> queues)
    {
        var toRemove = new List<ClientsEntity>();
        var date = DateTime.UtcNow;

        foreach (var queue in queues)
        {
            var count = 0;
            foreach (var client in queue.Clients!.OrderBy(o => o.RegistrationDate))
            {
                count += queue.DurationMinutes;
                var dif = (date - client.RegistrationDate).TotalMinutes;
                if (dif > count)
                {
                    toRemove.Add(client);
                    queue.Clients!.Remove(client);
                }
                else
                {
                    break;
                }
            }
        }

        return toRemove;
    }
}
