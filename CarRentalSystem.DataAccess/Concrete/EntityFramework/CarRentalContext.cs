using CarRentalSystem.DataAccess.Mapping;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:azuredbsqlserver.database.windows.net,1433;Initial Catalog=CarRental;Persist Security Info=False;User ID=serveradmin;Password=198719877aA*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           // optionsBuilder.UseSqlServer(@"Server=DESKTOP-03E9IUD;Database=CarRental;Trusted_Connection=True;");
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<RoleClaim>? RoleClaims { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Model>? Models { get; set; }
        public DbSet<Segment>? Segments { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new SegmentMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.Entity<AvailableCarsDto>().HasNoKey();
        }

    }
}
