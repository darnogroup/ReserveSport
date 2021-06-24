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
    [Migration("20210623214414_AddCollectionId")]
    partial class AddCollectionId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domin.Entity.ArticleModel", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleSummary")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ArticleTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Domin.Entity.BannerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Banner");
                });

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

                    b.Property<string>("Image")
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

            modelBuilder.Entity("Domin.Entity.CommentModel", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
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

            modelBuilder.Entity("Domin.Entity.OrderDetailModel", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Close")
                        .HasColumnType("bit");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ReserveId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ReserveId");

                    b.ToTable("OrderDetailModels");
                });

            modelBuilder.Entity("Domin.Entity.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<string>("OrderCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderModels");
                });

            modelBuilder.Entity("Domin.Entity.ReserveModel", b =>
                {
                    b.Property<int>("ReserveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Domin.Entity.SettingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsApiCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsNumberSender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telegram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YouTube")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZarinPal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("Domin.Entity.SmsAdminModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmsAdmin");
                });

            modelBuilder.Entity("Domin.Entity.SmsCustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmsCustomer");
                });

            modelBuilder.Entity("Domin.Entity.SmsGeneralModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCollection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActiveText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemporaryText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmsGeneral");
                });

            modelBuilder.Entity("Domin.Entity.SmsRememberModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollectionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmsRemember");
                });

            modelBuilder.Entity("Domin.Entity.SmsThankModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThankText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmsThank");
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

            modelBuilder.Entity("Domin.Entity.SubTicketModel", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("SubTicket");
                });

            modelBuilder.Entity("Domin.Entity.TicketModel", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Close")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TicketDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TicketStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Ticket");
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

            modelBuilder.Entity("Domin.Entity.BannerModel", b =>
                {
                    b.HasOne("Domin.Entity.CollectionModel", "Collection")
                        .WithMany("Banner")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Collection");
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

            modelBuilder.Entity("Domin.Entity.CommentModel", b =>
                {
                    b.HasOne("Domin.Entity.ArticleModel", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Article");

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

            modelBuilder.Entity("Domin.Entity.OrderDetailModel", b =>
                {
                    b.HasOne("Domin.Entity.OrderModel", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.ReserveModel", "ReserveModel")
                        .WithMany("OrderDetailModels")
                        .HasForeignKey("ReserveId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ReserveModel");
                });

            modelBuilder.Entity("Domin.Entity.OrderModel", b =>
                {
                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithMany("OrderModels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("Domin.Entity.SubTicketModel", b =>
                {
                    b.HasOne("Domin.Entity.TicketModel", "Ticket")
                        .WithMany("SubTicket")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithMany("SubTicket")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domin.Entity.TicketModel", b =>
                {
                    b.HasOne("Domin.Entity.UserModel", "User")
                        .WithMany("Ticket")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("Domin.Entity.ArticleModel", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domin.Entity.CityModel", b =>
                {
                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Domin.Entity.CollectionModel", b =>
                {
                    b.Navigation("Banner");

                    b.Navigation("Financial");

                    b.Navigation("Reserves");

                    b.Navigation("SportCollection");
                });

            modelBuilder.Entity("Domin.Entity.OrderModel", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Domin.Entity.ReserveModel", b =>
                {
                    b.Navigation("OrderDetailModels");
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

            modelBuilder.Entity("Domin.Entity.TicketModel", b =>
                {
                    b.Navigation("SubTicket");
                });

            modelBuilder.Entity("Domin.Entity.UserModel", b =>
                {
                    b.Navigation("Collection");

                    b.Navigation("Comments");

                    b.Navigation("OrderModels");

                    b.Navigation("SubTicket");

                    b.Navigation("Ticket");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
