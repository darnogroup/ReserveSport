﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210607111051_Bank")]
    partial class Bank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domin.Entity.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Domin.Entity.CollectionModel", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CollectionAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CollectionPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CollectionId");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("Domin.Entity.FinancialModel", b =>
                {
                    b.Property<int>("FinancialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("FinancialCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinancialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinancialPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinancialSheba")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FinancialId");

                    b.HasIndex("CollectionId")
                        .IsUnique();

                    b.ToTable("Financial");
                });

            modelBuilder.Entity("Domin.Entity.ReserveModel", b =>
                {
                    b.Property<int>("ReserveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Finish")
                        .HasColumnType("bit");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Reserved")
                        .HasColumnType("bit");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReserveId");

                    b.HasIndex("CollectionId");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("Domin.Entity.SportCollectionModel", b =>
                {
                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.HasKey("SportId", "CollectionId");

                    b.HasIndex("CollectionId");

                    b.ToTable("SportCollection");
                });

            modelBuilder.Entity("Domin.Entity.SportModel", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SportDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SportId");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("Domin.Entity.StateModel", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Domin.Entity.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domin.Entity.UserWalletModel", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WalletInventory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserWallet");
                });

            modelBuilder.Entity("Domin.Entity.CityModel", b =>
                {
                    b.HasOne("Domin.Entity.StateModel", "State")
                        .WithMany("City")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domin.Entity.CollectionModel", b =>
                {
                    b.HasOne("Domin.Entity.CityModel", "City")
                        .WithMany("Collection")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.StateModel", "State")
                        .WithMany("Collection")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithOne("Collection")
                        .HasForeignKey("Domin.Entity.CollectionModel", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domin.Entity.FinancialModel", b =>
                {
                    b.HasOne("Domin.Entity.CollectionModel", "Collection")
                        .WithOne("Financial")
                        .HasForeignKey("Domin.Entity.FinancialModel", "CollectionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Domin.Entity.ReserveModel", b =>
                {
                    b.HasOne("Domin.Entity.CollectionModel", "Collection")
                        .WithMany("Reserves")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Domin.Entity.SportCollectionModel", b =>
                {
                    b.HasOne("Domin.Entity.CollectionModel", "Collection")
                        .WithMany("SportCollection")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.SportModel", "Sport")
                        .WithMany("SportCollection")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("Domin.Entity.UserWalletModel", b =>
                {
                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("Domin.Entity.UserWalletModel", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domin.Entity.CityModel", b =>
                {
                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Domin.Entity.CollectionModel", b =>
                {
                    b.Navigation("Financial");

                    b.Navigation("Reserves");

                    b.Navigation("SportCollection");
                });

            modelBuilder.Entity("Domin.Entity.SportModel", b =>
                {
                    b.Navigation("SportCollection");
                });

            modelBuilder.Entity("Domin.Entity.StateModel", b =>
                {
                    b.Navigation("City");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Domin.Entity.UserModel", b =>
                {
                    b.Navigation("Collection");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
