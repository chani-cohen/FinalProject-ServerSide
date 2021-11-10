using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStreetDAL
    {
        Task<List<TblStreets>> GetAllStreetsAsync();
        Task<TblStreets> GetStreetByIdAsync(int id);
        Task AddStreetAsync(TblStreets s);
        Task UpdateStreetAsync(TblStreets s);
        Task DeleteStreetAsync(int id);
    }
}
