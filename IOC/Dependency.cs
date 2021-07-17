using System;
using Application.Interface;
using Application.Service;
using Data.Repository;
using Domin.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public  class Dependency
    {
        public static void Injection(IServiceCollection service)
        {
            #region Repository

            service.AddScoped<IStateInterface, StateRepository>();
            service.AddScoped<ICityInterface,CityRepository>();
            service.AddScoped<ISportInterface, SportRepository>();
            service.AddScoped<IUserInterface,UserRepository>();
            service.AddScoped<ICollectionInterface, CollectionRepository>();
            service.AddScoped<IReserveInterface, ReserveRepository>();
            service.AddScoped<IArticleInterface, ArticleRepository>();
            service.AddScoped<ISmsInterface,SmsRepository>();
            service.AddScoped<ISettingInterface, SettingRepository>();
            service.AddScoped<ITicketInterface, TicketRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IReserveSportRepository, ReserveSportRepository>();
            #endregion

            #region Service

            service.AddScoped<IStateService, StateService>();
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<ISportService, SportService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ICollectionService,CollectionService>();
            service.AddScoped<IReserveService, ReserveService>();
            service.AddScoped<IArticleService,ArticleService>();
            service.AddScoped<ISmsService, SmsService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<ISettingService,SettingService>();
            service.AddScoped<ITicketService,TicketService>();
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IOrderService, OrderService>();

            #endregion
        }
    }
}
