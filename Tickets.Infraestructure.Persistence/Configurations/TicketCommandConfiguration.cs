using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Entities;

namespace Tickets.Infraestructure.Persistence.Configurations
{
    public class TicketCommandConfiguration : IEntityTypeConfiguration<TicketComment>
    {
        public void Configure(EntityTypeBuilder<TicketComment> builder)
        {
            builder.ToTable(nameof(TicketComment));
            builder.HasKey(k => k.TicketCommentId);
            builder.Property(e => e.TicketCommentId).ValueGeneratedOnAdd();
            builder.Property(t => t.Comment).IsRequired().HasMaxLength(250);
        }
    }
}
