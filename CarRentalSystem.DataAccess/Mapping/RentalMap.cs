using CarRentalSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Mapping
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals");
            builder.HasKey(r => r.RentalId);
            builder.Property(r => r.RentalId).UseIdentityColumn(1, 1);
            builder.Property(rental => rental.Price).HasColumnType("money");
            builder.Property(rental => rental.State).HasColumnType("char").HasMaxLength(1);
            builder.Property(rental => rental.RentalDate).HasColumnType("datetime"); 
            builder.Property(rental => rental.ReturnDate).HasColumnType("datetime");
            builder.Property(rental => rental.DateProcessed).HasColumnType("datetime");
            builder.HasOne(r=>r.User).WithMany(u=>u.Rentals).HasForeignKey(u => u.UserId);
            builder.HasOne(r => r.Car).WithMany(c => c.Rentals).HasForeignKey(u => u.CarId);
            builder.HasOne(r => r.Customer).WithMany(c => c.Rentals).HasForeignKey(u => u.CustomerId);


        }
    }
}
