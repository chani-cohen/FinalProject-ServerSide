using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Classes;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
//בשביל חיבור צד הקליינט והסרבר
using Microsoft.AspNetCore.Cors;

namespace EF_Demo_Contacts.Controllers
{
    //בשביל חיבור צד הקליינט והסרבר
    [EnableCors()]

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderBL orderBL;

        public OrdersController(IOrderBL _orderBL)
        {
            this.orderBL = _orderBL;
        }


        [HttpPost("AddOrder")]
        public async Task<List<TblOrders>> AddOrderAsync(TblOrders o)
        {
            await this.orderBL.AddOrderAsync(o);
            return await this.orderBL.GetOrderByEmailAsync(o.Email);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<List<TblOrders>> DeleteOrderAsync(int id)
        {
            await this.orderBL.DeleteOrderAsync(id);
            return await this.orderBL.GetAllOrdersAsync();
        }

        [HttpDelete("DeleteOrdersByTravelId/{travelId}")]
        public async Task<List<TblOrders>> DeleteOrdersByTravelIdAsync(int travelId)
        {
            await this.orderBL.DeleteOrdersByTravelIdAsync(travelId);
            return await this.orderBL.GetOrderByTravelIdAsync(travelId);
        }

        [HttpGet("GetAllOrders")]
        public async Task<List<TblOrders>> GetAllOrdersAsync()
        {
            return await this.orderBL.GetAllOrdersAsync();
        }

        [HttpGet("GetOrderByEmail/{email}")]
        public async Task<List<TblOrders>> GetOrderByEmailAsync(string email)
        {
            return await this.orderBL.GetOrderByEmailAsync(email);
        }

        [HttpGet("GetOrderByTravelId/{travelId}")]
        public async Task<List<TblOrders>> GetOrderByTravelIdAsync(int travelId)
        {
            return await this.orderBL.GetOrderByTravelIdAsync(travelId);
        }

        [HttpPut("UpdateOrder")]
        public async Task<List<TblOrders>> UpdateOrderAsync(TblOrders o)
        {
            await this.orderBL.UpdateOrderAsync(o);
            return await this.orderBL.GetAllOrdersAsync();
        }

    }
}
