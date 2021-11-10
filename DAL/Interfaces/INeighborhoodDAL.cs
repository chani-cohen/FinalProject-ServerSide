using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface INeighborhoodDAL
    {
        Task<List<TblNeighborhoods>> GetAllNeighborhoodsAsync();
        Task<TblNeighborhoods> GetNeighborhoodByIdAsync(int id);
        Task AddNeighborhoodAsync(TblNeighborhoods s);
        Task UpdateNeighborhoodAsync(TblNeighborhoods s);
        Task DeleteNeighborhoodAsync(int id);
    }
}
