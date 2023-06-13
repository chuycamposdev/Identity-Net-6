using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Entities;

namespace Tickets.Infraestructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketComment> TicketComment { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
