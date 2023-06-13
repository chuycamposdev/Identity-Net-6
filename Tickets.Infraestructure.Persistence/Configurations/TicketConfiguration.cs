using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Entities;

namespace Tickets.Infraestructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(t => t.TicketId);
            builder.Property(e => e.TicketId).ValueGeneratedOnAdd();
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(t => t.FechaCreacion).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
