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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(b => b.BrandId);
            builder.Property(p => p.BrandId).UseIdentityColumn(1, 1);
            builder.Property(p => p.BrandName).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(b => b.State).HasColumnType("bit").HasDefaultValue(true);

        }
    }
}
