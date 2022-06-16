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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.ToTable("Users");
           builder.HasKey(u=>u.UserId);
           builder.Property(u => u.UserId).HasColumnType("int");
           builder.Property(u => u.UserId).UseIdentityColumn(1,1);
           builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(75);
           builder.Property(u => u.Name).HasColumnType("varchar").HasMaxLength(50);
           builder.Property(u => u.Surname).HasColumnType("varchar").HasMaxLength(50);
           builder.Property(u => u.PasswordHash).HasColumnType("varbinary").HasMaxLength(500);
           builder.Property(u => u.PasswordSalt).HasColumnType("varbinary").HasMaxLength(500);
           builder.Property(u => u.Address).HasColumnType("varchar").HasMaxLength(150);
           builder.Property(u => u.Gender).HasColumnType("char").HasMaxLength(1);
           builder.Property(u=>u.IdentityNumber).HasColumnType("varchar").HasMaxLength(11);
           builder.Property(u => u.SecurityQuestion).HasColumnType("varchar").HasMaxLength(100);
           builder.Property(u => u.SecurityQuestionAnswer).HasColumnType("varchar").HasMaxLength(50);
           builder.Property(u => u.PhoneNumber).HasColumnType("varchar").HasMaxLength(20);
           builder.Property(c => c.State).HasColumnType("bit").HasDefaultValue(true);
           builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);








        }
    }
}
