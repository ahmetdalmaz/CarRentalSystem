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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.CarId);
            builder.Property(c => c.CarId).UseIdentityColumn(1, 1);
            builder.Property(c => c.Color).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(c => c.Plate).HasColumnType("varchar").HasMaxLength(8);
            builder.Property(c => c.FuelType).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(c => c.Kilometre).HasColumnType("varchar").HasMaxLength(10);
            builder.Property(c => c.State).HasColumnType("bit").HasDefaultValue(true);
            builder.HasOne(c => c.Model).WithMany(m => m.Cars).HasForeignKey(c => c.ModelId);
            builder.HasOne(c => c.Segment).WithMany(s => s.Cars).HasForeignKey(c => c.SegmentId);



        }
    }
}
