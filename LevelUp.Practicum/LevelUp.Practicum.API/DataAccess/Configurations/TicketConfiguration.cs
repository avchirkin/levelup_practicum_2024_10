using LevelUp.Practicum.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Practicum.API.DataAccess.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("ticket");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.OwnerId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasOne<Passenger>(t => t.Owner)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.OwnerId);
    }
}