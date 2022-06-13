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
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaim");
            builder.HasKey(claim => claim.OperationClaimId);
            builder.Property(claim => claim.OperationClaimId).UseIdentityColumn(1,1);
            builder.Property(claim => claim.Name).HasColumnType("varchar").HasMaxLength(35);
            builder.Property(claim => claim.State).HasColumnType("bit").HasDefaultValue(1);
            builder.HasData(new OperationClaim { OperationClaimId = 1, Name = "admin"});

        }
    }
}
