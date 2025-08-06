using HelpDesk_Benedict.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Benedict.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<TicketComment>()
                .HasOne(tc => tc.Ticket)
                .WithMany(t => t.TicketComments)
                .HasForeignKey(tc => tc.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TicketComment>()
                .HasOne(tc => tc.User)
                .WithMany()
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t => t.Room)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
