namespace Domain.Entities;

public class ClientsEntity
{
    public int Id { get; set; }
    public int QueueId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }


    // Foreign keys
    public virtual QueuesEntity? Queue { get; set; }
}