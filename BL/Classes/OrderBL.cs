using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
using BL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL.Classes
{
    public class OrderBL : IOrderBL
    {
        IOrderDAL orderDAL;

        public OrderBL(IOrderDAL _orderDAL)
        {
            this.orderDAL = _orderDAL;
        }

        public async Task AddOrderAsync(TblOrders o)
        {
            await this.orderDAL.AddOrderAsync(o);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await this.orderDAL.DeleteOrderAsync(id);
        }

        public async Task DeleteOrdersByTravelIdAsync(int travelId)
        {
            await this.orderDAL.DeleteOrdersByTravelIdAsync(travelId);
        }

        public async Task<List<TblOrders>> GetAllOrdersAsync()
        {
            return await this.orderDAL.GetAllOrdersAsync();
        }

        public async Task<List<TblOrders>> GetOrderByEmailAsync(string email)
        {
            return await this.orderDAL.GetOrderByEmailAsync(email);
        }

        public async Task<List<TblOrders>> GetOrderByTravelIdAsync(int travelId)
        {
            return await this.orderDAL.GetOrderByTravelIdAsync(travelId);
        }

        public async Task UpdateOrderAsync(TblOrders o)
        {
            await this.orderDAL.UpdateOrderAsync(o);
        }
    }
}
