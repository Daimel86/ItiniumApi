using Domain.Entities;

namespace Repositories.Contracts;

public interface IClientsRepository
{

    Task<ClientsEntity> Add(ClientsEntity clients);
}
