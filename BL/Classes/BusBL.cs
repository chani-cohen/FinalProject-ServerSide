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
    public class BusBL: IBusBL
    {
        IBusDAL busDAL;

        public BusBL(IBusDAL _busDAL)
        {
            this.busDAL = _busDAL;
        }

        public async Task AddBusAsync(TblBusses b)
        {
            await this.busDAL.AddBusAsync(b);
        }

        public async Task DeleteBusAsync(string cmBus)
        {
            await this.busDAL.DeleteBusAsync(cmBus);
        }

        public async Task<List<TblBusses>> GetAllBussesAsync()
        {
            return await this.busDAL.GetAllBussesAsync();
        }

        public async Task<TblBusses> GetBusByCmBusAsync(string cmBus)
        {
            return await this.busDAL.GetBusByCmBusAsync(cmBus);
        }

        public async Task UpdateBusAsync(TblBusses b)
        {
            await this.busDAL.UpdateBusAsync(b);
        }
    }
}
