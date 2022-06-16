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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(claim => claim.RoleId);
            builder.Property(claim => claim.RoleId).UseIdentityColumn(1,1);
            builder.Property(claim => claim.Name).HasColumnType("varchar").HasMaxLength(35);
            builder.Property(claim => claim.State).HasColumnType("bit").HasDefaultValue(1);
            builder.HasData(new Role { RoleId = 1, Name = "admin"});

        }
    }
}
