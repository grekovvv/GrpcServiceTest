using GrpcService1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;

namespace GrpcService1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Book> Book { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Alex" },
                    new User { Id = 2, Name = "Max" },
                    new User { Id = 3, Name = "Ivan" }
            );

            /*modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Name = "Harry Potter", UserId = 1 },
                    new Book { Id = 2, Name = "Martin Eden", UserId = 1 },
                    new Book { Id = 3, Name = "Ender's Game", UserId = 2 }
            );*/
        }
    }
}
