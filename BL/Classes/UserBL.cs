using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BL.Interfaces;
using DAL.Interfaces;

namespace BL.Classes
{
    public class UserBL: IUserBL
    {
        IUserDAL userDAL;

        public UserBL(IUserDAL _userDAL)
        {
            this.userDAL = _userDAL;
        }
        public async Task AddUserAsync(TblUsers u, TblCustomers c)
        {
            await this.userDAL.AddUserAsync(u, c);
        }

        public async Task DeleteUserAsync(string email)
        {
            await this.userDAL.DeleteUserAsync(email);
        }

        public async Task<List<TblUsers>> GetAllUsersAsync()
        {
            return await this.userDAL.GetAllUsersAsync();
        }

        public async Task<TblUsers> GetUserByEmailAsync(string email)
        {
            return await this.userDAL.GetUserByEmailAsync(email);
        }

        public async Task UpdateUserAsync(TblUsers u)
        {
            await this.userDAL.UpdateUserAsync(u);
        }
    }
}
