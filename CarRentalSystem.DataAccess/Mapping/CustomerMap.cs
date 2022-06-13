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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerId);
            builder.Property(x=>x.CustomerId).UseIdentityColumn(1,1);
            builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(75);
            builder.Property(u => u.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(u => u.Surname).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(u => u.Address).HasColumnType("varchar").HasMaxLength(150);
            builder.Property(u => u.IdentityNumber).HasColumnType("varchar").HasMaxLength(15);
            builder.Property(u => u.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(c => c.State).HasColumnType("bit").HasDefaultValue(true);

        }
    }
}
