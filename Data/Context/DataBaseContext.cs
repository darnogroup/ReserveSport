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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.ClientCascade;
            }
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
