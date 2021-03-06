// <auto-generated />
using System;
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
    [Migration("20220316123936_CreateCarTables")]
    partial class CreateCarTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("BrandName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("BrandId");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Kilometre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("char(8)");

                    b.Property<int>("SegmentId")
                        .HasColumnType("int");

                    b.Property<bool?>("State")
                        .HasColumnType("bit");

                    b.HasKey("CarId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SegmentId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);
                });

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

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Segment", b =>
                {
                    b.Property<int>("SegmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SegmentId"), 1L, 1);

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("MonthlyPrice")
                        .HasColumnType("money");

                    b.Property<string>("SegmentName")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<decimal>("WeeklyPrice")
                        .HasColumnType("money");

                    b.HasKey("SegmentId");

                    b.ToTable("Segments", (string)null);
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

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

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

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Entities.Concrete.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Entities.Concrete.Segment", "Segment")
                        .WithMany("Cars")
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Model", b =>
                {
                    b.HasOne("CarRentalSystem.Entities.Concrete.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
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

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Model", b =>
                {
                    b.Navigation("Cars");
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

            modelBuilder.Entity("CarRentalSystem.Entities.Concrete.Segment", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
