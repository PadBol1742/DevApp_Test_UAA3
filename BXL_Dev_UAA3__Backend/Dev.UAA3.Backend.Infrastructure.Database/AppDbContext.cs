using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;

namespace Dev.UAA3.Backend.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                Room? roomChecker = context.Set<Room>().FirstOrDefault();
                if (roomChecker is null)
                {
                    context.Set<Room>().AddRange([
                        new Room("Salle 01"),
                        new Room("Salle 02"),
                        new Room("Salle 03"),
                        new Room("Salle 04"),
                        new Room("Salle 05"),
                    ]);
                    context.SaveChanges();
                }
            });
        }
    }
}