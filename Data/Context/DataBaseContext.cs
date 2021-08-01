using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        public virtual DbSet<StateModel> State { set; get; }
        public virtual DbSet<CityModel>City { set; get; }
        public virtual DbSet<SportModel>Sport { set; get; }
        public virtual DbSet<UserModel> User { set; get; }
        public virtual DbSet<UserWalletModel>UserWallet { set; get; }
        public virtual DbSet<CollectionModel>Collection { set; get; }
        public virtual DbSet<SportCollectionModel>SportCollection { set; get; }
        public virtual DbSet<ReserveModel>Reserve { set; get; }
        public virtual DbSet<FinancialModel>Financial { set; get; }
        public virtual DbSet<BannerModel>Banner { set; get; }
        public virtual DbSet<ArticleModel>Article { set; get; }
        public virtual DbSet<CommentModel>Comment { set; get; }
        public virtual DbSet<SmsThankModel>SmsThank { set; get; }
        public virtual DbSet<SmsAdminModel> SmsAdmin { set; get; }
        public virtual DbSet<SmsCustomerModel> SmsCustomer { set; get; }
        public virtual DbSet<SmsGeneralModel> SmsGeneral { set; get; }
        public virtual DbSet<SmsRememberModel> SmsRemember { set; get; }
        public virtual DbSet<SettingModel>Setting { set; get; }
        public virtual DbSet<TicketModel>Ticket { set; get; }
        public virtual DbSet<SubTicketModel>SubTicket { set; get; }
        public virtual DbSet<OrderModel> OrderModels { set; get; }
        public virtual DbSet<OrderDetailModel> OrderDetailModels { set; get; }
        public virtual DbSet<ReserveSportsModel> ReserveSportsModels { set; get; }
        public virtual DbSet<AdsViewModel>AdsModels { set; get; }
        public virtual DbSet<AboutModel>AboutModels { set; get; }
        public virtual DbSet<ContactModel>ContactModels { set; get; }
        public virtual DbSet<ComplaintModel>ComplaintModels { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.ClientCascade;
            }


            #region Cascade Delete

            // Remove Collection

            modelBuilder.Entity<BannerModel>()
        .HasOne(p => p.Collection)
        .WithMany(b => b.Banner)
        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SportCollectionModel>()
        .HasOne(p => p.Collection)
        .WithMany(b => b.SportCollection)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FinancialModel>()
        .HasOne(p => p.Collection)
        .WithOne(b => b.Financial)
        .OnDelete(DeleteBehavior.Cascade);


            // Remove Sport
            modelBuilder.Entity<SportCollectionModel>()
        .HasOne(p => p.Sport)
        .WithMany(b => b.SportCollection)
        .OnDelete(DeleteBehavior.Cascade);


            // Remove Reserve
            modelBuilder.Entity<ReserveSportsModel>()
        .HasOne(p => p.Reserve)
        .WithMany(b => b.ReserveSports)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetailModel>()
        .HasOne(p => p.ReserveModel)
        .WithMany(b => b.OrderDetailModels)
        .OnDelete(DeleteBehavior.Cascade);

            // Remove Order
            modelBuilder.Entity<OrderDetailModel>()
        .HasOne(p => p.Order)
        .WithMany(b => b.OrderDetails)
        .OnDelete(DeleteBehavior.Cascade);


            // Remove User
            modelBuilder.Entity<CommentModel>()
        .HasOne(p => p.User)
        .WithMany(b => b.Comments)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserWalletModel>()
        .HasOne(p => p.User)
        .WithOne(b => b.Wallet)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubTicketModel>()
        .HasOne(p => p.User)
        .WithMany(b => b.SubTicket)
        .OnDelete(DeleteBehavior.Cascade);

            // Remove Ticket
            modelBuilder.Entity<SubTicketModel>()
        .HasOne(p => p.Ticket)
        .WithMany(b => b.SubTicket)
        .OnDelete(DeleteBehavior.Cascade);

            // Remove Article
            modelBuilder.Entity<CommentModel>()
        .HasOne(p => p.Article)
        .WithMany(b => b.Comments)
        .OnDelete(DeleteBehavior.Cascade);


            #endregion

            modelBuilder.Entity<StateModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<CityModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<SportModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<ArticleModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<UserModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<CollectionModel>().HasQueryFilter(q => q.IsDelete == false);
            modelBuilder.Entity<SportCollectionModel>().HasKey(k=>new { k.SportId, k.CollectionId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
