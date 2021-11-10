using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class NeighborhoodDAL: INeighborhoodDAL
    {
        TravelsContext db;

        public NeighborhoodDAL(TravelsContext _db)
        {
            this.db = _db;
        }
        public async Task AddNeighborhoodAsync(TblNeighborhoods n)
        {
            await this.db.TblNeighborhoods.AddAsync(n);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteNeighborhoodAsync(int id)
        {
            TblNeighborhoods n = await this.db.TblNeighborhoods.FirstOrDefaultAsync(n1 => n1.NeighborhoodId == id);
            if (n != null)
            {
                this.db.TblNeighborhoods.Remove(n);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblNeighborhoods>> GetAllNeighborhoodsAsync()
        {
            return await this.db.TblNeighborhoods.OrderBy(n => n.NeighborhoodName).ToListAsync();
        }

        public async Task<TblNeighborhoods> GetNeighborhoodByIdAsync(int id)
        {
            return await this.db.TblNeighborhoods.FirstOrDefaultAsync(n => n.NeighborhoodId == id);
        }

        public async Task UpdateNeighborhoodAsync(TblNeighborhoods n1)
        {
            TblNeighborhoods n = await this.db.TblNeighborhoods.FirstOrDefaultAsync(n2 => n2.NeighborhoodId == n1.NeighborhoodId);
            if (n != null)
            {
                n.NeighborhoodName = n1.NeighborhoodName;
                //n.TblCustomers = n1.TblCustomers;
                //n.TblStations = n1.TblStations;
                //n.TblStreets = n1.TblStreets;
            }
            await this.db.SaveChangesAsync();
        }
    }
}
