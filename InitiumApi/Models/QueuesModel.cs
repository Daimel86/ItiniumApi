using Domain.Entities;

namespace Models;

public class QueuesModel
{
    public int Id { get; set; }
    public string QueueName { get; set; } = null!;
    public int DurationMinutes { get; set; }
    public List<ClientModelGet>? Clients { get; set; }

    public static implicit operator QueuesModel(QueuesEntity entity) =>
        new()
        {
            Id = entity.Id,
            QueueName = entity.QueueName,
            DurationMinutes = entity.DurationMinutes,
            Clients = entity.Clients?.Select(c => (ClientModelGet)c).ToList(),
        };
}
