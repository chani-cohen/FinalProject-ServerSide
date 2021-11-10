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
    public class CustomerBL : ICustomerBL
    {
        ICustomerDAL customerDAL;

        public CustomerBL(ICustomerDAL _customerDAL)
        {
            this.customerDAL = _customerDAL;
        }

        public async Task AddCustomerAsync(TblCustomers c)
        {
            await this.customerDAL.AddCustomerAsync(c);
        }

        public async Task DeleteCustomerAsync(string email)
        {
            await this.customerDAL.DeleteCustomerAsync(email);
        }

        public async Task<List<TblCustomers>> GetAllCustomersAsync()
        {
            return await this.customerDAL.GetAllCustomersAsync();
        }

        public async Task<TblCustomers> GetCustomerByEmailAsync(string email)
        {
            return await this.customerDAL.GetCustomerByEmailAsync(email);
        }

        public async Task UpdateCustomerAsync(TblCustomers c)
        {
            await this.customerDAL.UpdateCustomerAsync(c);
        }
    }
}
