using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly InitiumDbContext _initiumDbContext;

    public ClientsRepository(InitiumDbContext initiumDbContext) =>
        _initiumDbContext = initiumDbContext;

    public async Task<ClientsEntity> Add(ClientsEntity client)
    {
        var existClientWithSameId = await _initiumDbContext.Clients.AnyAsync(a => a.Id == client.Id);
        if (existClientWithSameId) throw new Exception("Client Id already exists");

        var queues = await _initiumDbContext.Queues.Include(i => i.Clients).ToListAsync();
        if (!queues.Any()) throw new Exception("No hay colas");

        client.RegistrationDate = DateTime.UtcNow;

        var firstQueue = queues.OrderBy(o => o.Clients!.Count * o.DurationMinutes).First();
        client.QueueId = firstQueue.Id;

        var res = await _initiumDbContext.Clients.AddAsync(client);
        await _initiumDbContext.SaveChangesAsync();

        return res.Entity;
    }
}