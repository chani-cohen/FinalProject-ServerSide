using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        Task<List<TblUsers>> GetAllUsersAsync();
        Task<TblUsers> GetUserByEmailAsync(string email);
        Task AddUserAsync(TblUsers u, TblCustomers c);
        Task UpdateUserAsync(TblUsers u);
        Task DeleteUserAsync(string email);
    }
}
