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
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models");
            builder.HasKey(m => m.ModelId);
            builder.Property(m => m.ModelId).UseIdentityColumn(1, 1);
            builder.Property(m => m.ModelName).HasColumnType("varchar").HasMaxLength(40);
            builder.HasOne(m=>m.Brand).WithMany(b => b.Models).HasForeignKey(m => m.BrandId);
            builder.Property(c => c.State).HasColumnType("bit").HasDefaultValue(true);
         
        }
    }
}
