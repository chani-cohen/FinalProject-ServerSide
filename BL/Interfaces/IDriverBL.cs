using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface IDriverBL
    {
        Task<List<TblDrivers>> GetAllDriversAsync();
        Task<TblDrivers> GetDriverBytzAsync(string tz);
        Task AddDriverAsync(TblDrivers d);
        Task UpdateDriverAsync(TblDrivers d);
        Task DeleteDriverAsync(string tz);
    }
}
