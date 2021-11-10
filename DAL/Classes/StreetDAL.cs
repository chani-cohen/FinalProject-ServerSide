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
    public class StreetDAL: IStreetDAL
    {
        TravelsContext db;

        public StreetDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddStreetAsync(TblStreets s)
        {
            await this.db.TblStreets.AddAsync(s);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteStreetAsync(int id)
        {
            TblStreets s = await this.db.TblStreets.FirstOrDefaultAsync(s1 => s1.StreetId == id);
            if (s != null)
            {
                this.db.TblStreets.Remove(s);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblStreets>> GetAllStreetsAsync()
        {
            return await this.db.TblStreets.OrderBy(s=> s.StreetName).ToListAsync();
        }

        public async Task<TblStreets> GetStreetByIdAsync(int id)
        {
            return await this.db.TblStreets.FirstOrDefaultAsync(s => s.StreetId == id);
        }

        public async Task UpdateStreetAsync(TblStreets s2)
        {
            TblStreets s = await this.db.TblStreets.FirstOrDefaultAsync(s1 => s1.StreetId == s2.StreetId);
            if (s != null)
            {
                s.StreetName = s2.StreetName;               
            }
            await this.db.SaveChangesAsync();
        }
    }
}
