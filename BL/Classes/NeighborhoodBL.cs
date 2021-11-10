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
    public class NeighborhoodBL: INeighborhoodBL
    {
        INeighborhoodDAL NeighborhoodDAL;

        public NeighborhoodBL(INeighborhoodDAL _NeighborhoodDAL)
        {
            this.NeighborhoodDAL = _NeighborhoodDAL;
        }
        public async Task AddNeighborhoodAsync(TblNeighborhoods n)
        {
            await this.NeighborhoodDAL.AddNeighborhoodAsync(n);
        }

        public async Task DeleteNeighborhoodAsync(int id)
        {
            await this.NeighborhoodDAL.DeleteNeighborhoodAsync(id);
        }

        public async Task<List<TblNeighborhoods>> GetAllNeighborhoodsAsync()
        {
            return await this.NeighborhoodDAL.GetAllNeighborhoodsAsync();
        }

        public async Task<TblNeighborhoods> GetNeighborhoodByIdAsync(int id)
        {
            return await this.NeighborhoodDAL.GetNeighborhoodByIdAsync(id);
        }

        public async Task UpdateNeighborhoodAsync(TblNeighborhoods n)
        {
            await this.NeighborhoodDAL.UpdateNeighborhoodAsync(n);
        }
    }
}
