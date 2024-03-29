﻿using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DataBaseContext _context;

        public OrderRepository(DataBaseContext context)
        {
            _context = context;
        }
        #region Orders

        public void CreateOrder(OrderModel order)
        {
            _context.Add(order);
            Save();
        }
        public async Task<OrderModel> GetOrderByUserId(int userId)
        {
            return await _context.OrderModels.SingleOrDefaultAsync(n=> n.UserId == userId);
        }
        public async Task<OrderModel> GetNotFinalyOrderByUserId(int userId)
        {
            return await _context.OrderModels.SingleOrDefaultAsync(n => n.UserId == userId && !n.IsFinally);
        }
        public async Task<OrderModel> GetOrderById(int orderId)
        {
            return await _context.OrderModels.SingleOrDefaultAsync(n=> n.OrderId == orderId);
        }
        public void UpdateOrder(OrderModel order)
        {
            _context.Update(order);
            Save();
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            return await _context.OrderModels
                .Include(i => i.User).ToListAsync();
        }

        public void RemoveOrder(OrderModel order)
        {
            _context.OrderModels.Remove(order);
            Save();
        }

        public async Task<IEnumerable<OrderDetailModel>> GetCollectionOrdersItem(int id)
        {
            return await _context.OrderDetailModels.Where(w => w.CollectionId == id&&w.Close==true)
                .Include(i=>i.ReserveModel).Include(i=>i.Order).ThenInclude(t=>t.User).ToListAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetByUserId(int id)
        {
            return await _context.OrderModels.Where(w => w.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetailModel>> GetOrderDetails()
        {
            return await _context.OrderDetailModels.Where(w => w.Close == true)
                .Include(i => i.Order)
                .ThenInclude(t => t.User)
                .Include(i => i.ReserveModel).ThenInclude(t => t.Collection)
                .ToListAsync();
        }
        public async Task<bool> IsExistOrderByUserId(int userId)
        {
            return await _context.OrderModels.AnyAsync(n=> n.UserId == userId);
        }
        #endregion

        #region Details

        public async Task<bool> IsExistDetail(int reserveId,int sportId)
        {
            return await _context.OrderDetailModels.AnyAsync(o => o.ReserveId == reserveId && o.SportId == sportId);
        }
        public async Task<bool> IsExistDetail(DateTime date, int collectionId, int sportId)
        {
            return await _context.OrderDetailModels.Include(n=> n.ReserveModel).AnyAsync(o => o.ReserveModel.DayTime == date && o.SportId == sportId && o.ReserveModel.CollectionId == collectionId);
        }

        public async Task<IEnumerable<OrderDetailModel>> GetOrdersItem(int id)
        {
            return await _context.OrderDetailModels.Where(w => w.OrderId == id).Include(i=>i.Order).ThenInclude(t=>t.User)
                .Include(i => i.ReserveModel).ThenInclude(t=>t.Collection).ToListAsync();
        }

        public async Task<int> GetUserId(int userId)
        {
            return await _context.OrderModels.Where(w => w.UserId == userId && w.IsFinally == false)
                .Select(s => s.OrderId)
                .SingleOrDefaultAsync();
        }
        public void CreateDetail(OrderDetailModel detail)
        {
            _context.Add(detail);
            Save();
        }
        public int OrderPrice(int orderId)
        {
            return _context.OrderDetailModels.Where(n => n.OrderId == orderId).Sum(n => n.Price);
        }
        public async Task<IEnumerable<OrderDetailModel>> GetOrderItems(int orderId)
        {
            return await _context.OrderDetailModels.Where(w => w.OrderId == orderId && !w.Order.IsFinally).Include(i => i.ReserveModel)
                .ThenInclude(t => t.Collection).ToListAsync();
        }
        public async Task<OrderDetailModel> GetDetailById(int id)
        {
            return await _context.OrderDetailModels.SingleOrDefaultAsync(n=> n.DetailId == id);
        }
        public void RemoveDetail(OrderDetailModel detail)
        {
            _context.Remove(detail);
            Save();
        }
        public async Task<ReserveModel> GetReserveByInfos(int collectionId, string reserve, string reserveTime)
        {
            return await _context.Reserve.SingleOrDefaultAsync(n=> n.CollectionId == collectionId);
        }
        public async Task<int> DetailsCountByOrderId(int orderId)
        {
            return await _context.OrderDetailModels.CountAsync(n=> n.OrderId == orderId);
        }
        public async Task<int> GetDetailsCount(int orderId)
        {
            return await _context.OrderDetailModels.Include(n => n.Order).CountAsync(n => n.OrderId == orderId && !n.Order.IsFinally);
        }

        public void UpdateDetail(OrderDetailModel model)
        {
            _context.Update(model);Save();
        }

        #endregion
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
