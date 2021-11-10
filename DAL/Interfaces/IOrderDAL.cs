using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderDAL
    {
        Task<List<TblOrders>> GetAllOrdersAsync();
        Task<List<TblOrders>> GetOrderByEmailAsync(string email);
        Task<List<TblOrders>> GetOrderByTravelIdAsync(int travelId); 
        Task AddOrderAsync(TblOrders o);
        Task UpdateOrderAsync(TblOrders o);
        Task DeleteOrderAsync(int id);
        Task DeleteOrdersByTravelIdAsync(int travelId);  
    }
}
