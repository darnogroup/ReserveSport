using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace ReserveSport.Jobs
{
    [DisallowConcurrentExecution]
    public class RemoveCartItem:IJob
    {
        
        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<DataBaseContext>();
            option.UseSqlServer("Server=.;Database=ReserveSport;Trusted_Connection=True;");
            using (DataBaseContext _ctx = new DataBaseContext(option.Options))
            {
                var order = _ctx.OrderModels.Where(w => w.IsFinally == false && w.CreateDate < DateTime.Now.AddHours(-24)).ToList();
                foreach (var itemOrder in order)
                {
                    var orderDetail = _ctx.OrderDetailModels.Where(w => w.OrderId == itemOrder.OrderId).ToList();
                    foreach (var item in orderDetail)
                    {
                        _ctx.OrderDetailModels.Remove(item);
                        _ctx.SaveChanges();
                        var itemReserve =
                            _ctx.ReserveSportsModels.Where(s => s.ReserveId == item.ReserveId).ToList();
                        foreach (var item2 in itemReserve)
                        {
                            item2.IsReserved = false; 
                            _ctx.Update(item2);
                            _ctx.Update(item2);
                        }
                      


                    }

                    _ctx.OrderModels.Remove(itemOrder);
                    _ctx.SaveChanges();
                }
            }
            return Task.CompletedTask;
        }
    }
}
 