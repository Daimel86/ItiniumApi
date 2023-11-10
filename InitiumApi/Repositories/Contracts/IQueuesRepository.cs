using Domain.Entities;

namespace Repositories.Contracts;

public interface IQueuesRepository
{
    Task<IEnumerable<QueuesEntity>> GetQueuesAsync();
}
