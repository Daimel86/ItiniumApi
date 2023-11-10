using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityTypeConfigurations;

public class QueuesEntityTypeConfiguration : IEntityTypeConfiguration<QueuesEntity>
{
    public void Configure(EntityTypeBuilder<QueuesEntity> builder)
    {
        builder.ToTable("Queue", "dbo");

        builder.HasKey(k => k.Id);

        builder.Property(x => x.QueueName).HasColumnName("QueueName").HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
        builder.Property(x => x.DurationMinutes).HasColumnName("DurationMinutes").HasColumnType("int").IsRequired();
    }
}
