using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class DriverDAL : IDriverDAL
    {
        TravelsContext db;
        public DriverDAL(TravelsContext _db)
        {
            this.db = _db;
        }
        public async Task AddDriverAsync(TblDrivers d)
        {
            //לבדוק שנהג לא קיים כבר עם תעודת זהות כזו
            
            
            await this.db.AddAsync(d);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteDriverAsync(string tz)
        {
            TblDrivers d = await this.db.TblDrivers.FirstOrDefaultAsync(d1 => d1.Tz.Equals(tz));
            if (d!= null) { 
                this.db.TblDrivers.Remove(d);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblDrivers>> GetAllDriversAsync()
        {
            return await this.db.TblDrivers.ToListAsync();
        }

        public async Task<TblDrivers> GetDriverBytzAsync(string tz)
        {
            return await this.db.TblDrivers.FirstOrDefaultAsync(d => d.Tz.Equals(tz));
        }

        public async Task UpdateDriverAsync(TblDrivers d1)
        {
            TblDrivers d = await this.db.TblDrivers.FirstOrDefaultAsync(d2 => d2.DriverId == d1.DriverId);
            if (d != null)
            {
                d.FirstName = d1.FirstName;
                d.LastName = d1.LastName;
                d.Phone = d1.Phone;
                d.Status = d1.Status;
                d.Tz = d1.Tz;
                //d.TblBoringBussesForTravels= d1.TblBoringBussesForTravels;
            }
            await this.db.SaveChangesAsync();
        }
    }
}
