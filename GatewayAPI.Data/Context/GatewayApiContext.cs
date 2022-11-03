using Microsoft.EntityFrameworkCore;
using GatewayAPI.Models.Entities;
namespace GatewayAPI.Data.Context
{
    public class GatewayApiContext : DbContext
    {
       
        public GatewayApiContext(DbContextOptions<GatewayApiContext> options) : base(options) {
            
            
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Gateway>().HasData(new Gateway()
                {
                    Id = 1,
                    Name = "Londres",
                    SerialNumber = "54564",
                    Address = "15.15.15.2",
                
                });

            modelBuilder.Entity<Peripheral>().HasData(new Peripheral()
                {
                    Id=1,
                    UID = 123456,
                    Vendor = "Vendor1",
                    DateTime = new DateTime(),
                    Status = "online",
                    GatewayId = 1,
                });
            modelBuilder.Entity<Gateway>().HasData(new Gateway()
                {
                    Id=2,
                    Name = "NY",
                    SerialNumber = "54564",
                    Address = "15.15.15.2",               
                  
                 });
            modelBuilder.Entity<Peripheral>().HasData(new Peripheral()
            {
                Id = 2,
                UID = 123456,
                Vendor = "Vendor1",
                DateTime = new DateTime(),
                Status = "online",
                GatewayId = 2,
            });
            modelBuilder.Entity<Peripheral>().HasData(new Peripheral()
            {
                Id = 3,
                UID = 123456,
                Vendor = "Vendor1",
                DateTime = new DateTime(),
                Status = "online",
                GatewayId = 2,
            });

        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Peripheral> Peripherals { get; set; }
    }
}
