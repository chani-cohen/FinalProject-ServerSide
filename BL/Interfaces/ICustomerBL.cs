using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface ICustomerBL
    {
        Task<List<TblCustomers>> GetAllCustomersAsync();
        Task<TblCustomers> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(TblCustomers c);
        Task UpdateCustomerAsync(TblCustomers c);
        Task DeleteCustomerAsync(string email);
    }
}
