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
    public class CustomersController : ControllerBase
    {
        ICustomerBL customerBL;

        public CustomersController(ICustomerBL _customerBL)
        {
            customerBL = _customerBL;
        }

        [HttpPost("AddCustomer")]
        public async Task<List<TblCustomers>> AddCustomerAsync(TblCustomers c)
        {
            await this.customerBL.AddCustomerAsync(c);
            return await customerBL.GetAllCustomersAsync();
        }

        [HttpDelete("DeleteCustomer/{email}")]
        public async Task<List<TblCustomers>> DeleteCustomerAsync(string email)
        {
            await this.customerBL.DeleteCustomerAsync(email);
            return await customerBL.GetAllCustomersAsync();
        }

        [HttpGet("GetAllCustomers")]
        public async Task<List<TblCustomers>> GetAllCustomersAsync()
        {
            return await this.customerBL.GetAllCustomersAsync();
        }

        [HttpGet("GetCustomerByEmail/{email}")]
        public async Task<TblCustomers> GetCustomerByEmailAsync(string email)
        {
            return await this.customerBL.GetCustomerByEmailAsync(email);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<List<TblCustomers>> UpdateCustomerAsync(TblCustomers c)
        {
            await this.customerBL.UpdateCustomerAsync(c);
            return await this.customerBL.GetAllCustomersAsync();
        }
    }
}
