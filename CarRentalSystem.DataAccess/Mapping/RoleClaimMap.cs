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
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims");
            builder.HasKey(uclaim => uclaim.RoleClaimId);
            builder.Property(upclaim=> upclaim.RoleClaimId).UseIdentityColumn(1,1);
            
            builder.HasOne(uclaim => uclaim.Role).WithMany(oclaim => oclaim.RoleClaims).HasForeignKey(uclaim => uclaim.RoleId);

            builder.HasData(new RoleClaim { RoleClaimId = 1, RoleId = 1, Name = "car.view" });
            builder.HasData(new RoleClaim { RoleClaimId = 2, RoleId = 1, Name = "car.add" });
            builder.HasData(new RoleClaim { RoleClaimId = 3, RoleId = 1, Name = "car.update" });
            builder.HasData(new RoleClaim { RoleClaimId = 4, RoleId = 1, Name = "car.delete" });

            builder.HasData(new RoleClaim { RoleClaimId = 5, RoleId = 1, Name = "rental.view" });

            builder.HasData(new RoleClaim { RoleClaimId = 6, RoleId = 1, Name = "roles.view" });
            builder.HasData(new RoleClaim { RoleClaimId = 7, RoleId = 1, Name = "roles.add" });
            builder.HasData(new RoleClaim { RoleClaimId = 8, RoleId = 1, Name = "roles.update" });
            builder.HasData(new RoleClaim { RoleClaimId = 9, RoleId = 1, Name = "roles.delete" });

            builder.HasData(new RoleClaim { RoleClaimId = 10, RoleId = 1, Name = "settings.view" });
            builder.HasData(new RoleClaim { RoleClaimId = 11, RoleId = 1, Name = "settings.add" });
            builder.HasData(new RoleClaim { RoleClaimId = 12, RoleId = 1, Name = "settings.update" });
            builder.HasData(new RoleClaim { RoleClaimId = 13, RoleId = 1, Name = "settings.delete" });

            builder.HasData(new RoleClaim { RoleClaimId = 14, RoleId = 1, Name = "customer.view" });
            builder.HasData(new RoleClaim { RoleClaimId = 15, RoleId = 1, Name = "customer.add" });
            builder.HasData(new RoleClaim { RoleClaimId = 16, RoleId = 1, Name = "customer.update" });
            builder.HasData(new RoleClaim { RoleClaimId = 17, RoleId = 1, Name = "customer.delete" });

            builder.HasData(new RoleClaim { RoleClaimId = 18, RoleId = 1, Name = "user.view" });
            builder.HasData(new RoleClaim { RoleClaimId = 19, RoleId = 1, Name = "user.add" });
            builder.HasData(new RoleClaim { RoleClaimId = 20, RoleId = 1, Name = "user.update" });
            builder.HasData(new RoleClaim { RoleClaimId = 21, RoleId = 1, Name = "user.delete" });

            builder.HasData(new RoleClaim { RoleClaimId = 22, RoleId = 1, Name = "statistic.view" });
        }
    }
}
