using CarWashEF.Model;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace CarWashEF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Servant> Servants { get; set; } = null;
        public DbSet<OwnOrder> OwnOrders { get; set; } = null;
        public DbSet<Order> Orders { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<OrderServant> OrderServants { get; set; } = null;

        public AppDbContext() 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * WITH DEFAULT VALUE
            modelBuilder.Entity<Servant>()
                .Property(b => b.Name)
                .Has(""); //Change method to make another constraint
            */
            modelBuilder.Entity<OwnOrderServant>()
                .HasKey(sc => new { sc.OwnOrderId, sc.ServantId });

            modelBuilder.Entity<OrderServant>()
                .HasKey(sc => new { sc.OrderId, sc.ServantId });

            modelBuilder.Entity<Servant>().HasData(
                    new Servant { Id = 1, Name = "Windows washing", Time = 15, Price = 200, ServantType = ServantType.WASH },
                    new Servant { Id = 2, Name = "Windows polishing", Time = 10, Price = 100, ServantType = ServantType.POLISHING },
                    new Servant { Id = 3, Name = "Full washing", Time = 60, Price = 750, ServantType = ServantType.WASH },
                    new Servant { Id = 4, Name = "Full polishing", Time = 70, Price = 500, ServantType = ServantType.POLISHING },
                    new Servant { Id = 5, Name = "Dry cleaning", Time = 120, Price = 2000, ServantType = ServantType.DRY_CLEANERS },
                    new Servant { Id = 6, Name = "NEW", Time = 0, Price = 0, ServantType = ServantType.DRY_CLEANERS }
                );
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TERACT10SLAPTOP;Database=car_wash;Integrated Security=True;");
        }
    }
}
