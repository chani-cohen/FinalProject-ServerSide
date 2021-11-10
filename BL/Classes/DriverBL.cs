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
    public class DriverBL: IDriverBL
    {
        IDriverDAL driverDAL;

        public DriverBL(IDriverDAL _driverDAL)
        {
            this.driverDAL = _driverDAL;
        }

        public async Task AddDriverAsync(TblDrivers d)
        {
            await this.driverDAL.AddDriverAsync(d);
        }

        public async Task DeleteDriverAsync(string tz)
        {
            await this.driverDAL.DeleteDriverAsync(tz);
        }

        public async Task<List<TblDrivers>> GetAllDriversAsync()
        {
            return await this.driverDAL.GetAllDriversAsync();
        }

        public async Task<TblDrivers> GetDriverBytzAsync(string tz)
        {
            return await this.driverDAL.GetDriverBytzAsync(tz);
        }

        public async Task UpdateDriverAsync(TblDrivers d)
        {
            await this.driverDAL.UpdateDriverAsync(d);
        }
    }
}
