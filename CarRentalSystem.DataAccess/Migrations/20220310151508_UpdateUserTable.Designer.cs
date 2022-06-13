﻿// <auto-generated />
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalSystem.DataAccess.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    [Migration("20220310151508_UpdateUserTable")]
    partial class UpdateUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions", (string)null);

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Name = "Ekleme"
                        },
                        new
                        {
                            PermissionId = 2,
                            Name = "Silme"
                        },
                        new
                        {
                            PermissionId = 3,
                            Name = "Güncelleme"
                        },
                        new
                        {
                            PermissionId = 4,
                            Name = "Görüntüleme"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin",
                            State = true
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolePermissionId"), 1L, 1);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions", (string)null);

                    b.HasData(
                        new
                        {
                            RolePermissionId = 1,
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 2,
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 3,
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 4,
                            PermissionId = 4,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Email")
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)");

                    b.Property<string>("IdentityNumber")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Password")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityQuestion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SecurityQuestionAnswer")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.RolePermission", b =>
                {
                    b.HasOne("CarRentalSystem.Entities.Concrete.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Entities.Concrete.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.User", b =>
                {
                    b.HasOne("CarRentalSystem.Entities.Concrete.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
