﻿// <auto-generated />
using License.Creation.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace License.Creation.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221214114713_InstallationTypes")]
    partial class InstallationTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("License.Creation.Api.Data.ContractType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("dwcontracttypes");
                });

            modelBuilder.Entity("License.Creation.Api.Data.InstallationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DWInstallationTypes");
                });

            modelBuilder.Entity("License.Creation.Api.Data.InstallationTypesToLicenseProductsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("InstallationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LicenseProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstallationTypeId");

                    b.HasIndex("LicenseProductId");

                    b.ToTable("DWInstallationTypesToLicenseProducts");
                });

            modelBuilder.Entity("License.Creation.Api.Data.LicenseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IssuedType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("dwlicenseproducts");
                });

            modelBuilder.Entity("License.Creation.Api.Data.InstallationTypesToLicenseProductsModel", b =>
                {
                    b.HasOne("License.Creation.Api.Data.InstallationType", "InstallationType")
                        .WithMany("ProductRelations")
                        .HasForeignKey("InstallationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("License.Creation.Api.Data.LicenseProduct", "LicenseProduct")
                        .WithMany()
                        .HasForeignKey("LicenseProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstallationType");

                    b.Navigation("LicenseProduct");
                });

            modelBuilder.Entity("License.Creation.Api.Data.InstallationType", b =>
                {
                    b.Navigation("ProductRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
