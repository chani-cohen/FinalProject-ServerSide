using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerDAL
    {
        Task<List<TblCustomers>> GetAllCustomersAsync();
        Task<TblCustomers> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(TblCustomers c);
        Task UpdateCustomerAsync(TblCustomers c);
        Task DeleteCustomerAsync(string email);
    }
}
