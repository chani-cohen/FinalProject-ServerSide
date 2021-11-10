using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface IUserBL
    {
        Task<List<TblUsers>> GetAllUsersAsync();
        Task<TblUsers> GetUserByEmailAsync(string email);
        Task AddUserAsync(TblUsers u, TblCustomers c);
        Task UpdateUserAsync(TblUsers u);
        Task DeleteUserAsync(string email);
    }
}
