using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using ReserveSport.Other;

namespace ReserveSport.Areas.Customer.Component
{
    public class OrederCustomerVC:ViewComponent
    {
        private readonly IOrderService _order;

        public OrederCustomerVC(IOrderService order)
        {
            _order = order;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            return View("/Views/Shared/Component/OrderCutomer.cshtml", _order.GetOrders(id).Result);
        }
    }
}
