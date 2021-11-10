using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Classes
{
    public class BusDAL: IBusDAL
    {
        TravelsContext db;

        public BusDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddBusAsync(TblBusses b)
        {
            await this.db.TblBusses.AddAsync(b);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteBusAsync(string cmBus)
        {
            TblBusses b = await this.db.TblBusses.FirstOrDefaultAsync(b1 => b1.CmBus.Equals(cmBus));
            if (b != null)
            {
                this.db.TblBusses.Remove(b);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblBusses>> GetAllBussesAsync()
        {
            return await this.db.TblBusses.ToListAsync();
        }

        public async Task<TblBusses> GetBusByCmBusAsync(string cmBus)
        {
            return await this.db.TblBusses.FirstOrDefaultAsync(b => b.CmBus.Equals(cmBus));
        }

        public async Task UpdateBusAsync(TblBusses b1)
        {
            TblBusses b = await this.db.TblBusses.FirstOrDefaultAsync(b2 => b2.CmBus.Equals(b1.CmBus));
            if (b != null)
            {
                b.Company = b1.Company;
                b.Status = b1.Status;
                //לא ניתן לעדכן מק"ט אוטובוס
            }
            await this.db.SaveChangesAsync();
        }
    }
}
