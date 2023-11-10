using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations;

public class ClientsEntityTypeConfiguration : IEntityTypeConfiguration<ClientsEntity>
{
    public void Configure(EntityTypeBuilder<ClientsEntity> builder)
    {
        builder.ToTable("Clients", "dbo");

        builder.HasKey(k => k.Id);

        builder.Property(x => x.ClientName).HasColumnName("ClientName").HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
        builder.Property(x => x.RegistrationDate).HasColumnName("RegistrationDate").HasColumnType("datetime").IsRequired();

        builder.HasOne(q => q.Queue)
                   .WithMany(b => b.Clients)
                   .HasForeignKey(c => c.QueueId)
                   .OnDelete(DeleteBehavior.Restrict);
    }
}
