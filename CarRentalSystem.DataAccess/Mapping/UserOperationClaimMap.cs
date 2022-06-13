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
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaim");
            builder.HasKey(uclaim => uclaim.UserOperationClaimId);
            builder.Property(upclaim=> upclaim.UserOperationClaimId).UseIdentityColumn(1,1);
            builder.HasOne(uclaim => uclaim.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uclaim => uclaim.UserId);
            builder.HasOne(uclaim => uclaim.OperationClaim).WithMany(oclaim => oclaim.UserOperationClaims).HasForeignKey(uclaim => uclaim.OperationClaimId);
            
           
        }
    }
}
