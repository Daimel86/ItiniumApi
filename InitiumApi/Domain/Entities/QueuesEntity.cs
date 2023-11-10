namespace Domain.Entities;

public class QueuesEntity
{
    public int Id { get; set; }
    public string QueueName { get; set; } = null!;
    public int DurationMinutes { get; set; }

    // Reverse navigation
    public virtual ICollection<ClientsEntity>? Clients { get; set; }
}
