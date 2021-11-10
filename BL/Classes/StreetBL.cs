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
    public class StreetBL : IStreetBL
    {
        IStreetDAL streetDAL;

        public StreetBL(IStreetDAL _streetDAL)
        {
            this.streetDAL = _streetDAL;
        }

        public async Task AddStreetAsync(TblStreets s)
        {
            await this.streetDAL.AddStreetAsync(s); 
        }

        public async Task DeleteStreetAsync(int id)
        {
            await this.streetDAL.DeleteStreetAsync(id);
        }

        public async Task<List<TblStreets>> GetAllStreetsAsync()
        {
            return await this.streetDAL.GetAllStreetsAsync();
        }

        public async Task<TblStreets> GetStreetByIdAsync(int id)
        {
            return await this.streetDAL.GetStreetByIdAsync(id);
        }

        public async Task UpdateStreetAsync(TblStreets s)
        {
            await this.streetDAL.UpdateStreetAsync(s);
        }
    }
}
