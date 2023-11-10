using Domain.EntityTypeConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Context.Contracts;

namespace Domain.Context;

public class InitiumDbContext : DbContext, IInitiumDbContext
{
    public DbSet<ClientsEntity> Clients { get; set; }
    public DbSet<QueuesEntity> Queues { get; set; }

    public InitiumDbContext(DbContextOptions<InitiumDbContext> optionsBuilder) : base(optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientsEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
