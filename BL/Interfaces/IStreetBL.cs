using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IStreetBL
    {
        Task<List<TblStreets>> GetAllStreetsAsync();
        Task<TblStreets> GetStreetByIdAsync(int id);
        Task AddStreetAsync(TblStreets s);
        Task UpdateStreetAsync(TblStreets s);
        Task DeleteStreetAsync(int id);
    }
}
