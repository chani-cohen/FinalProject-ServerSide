using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace BL.Interfaces
{
    public interface INeighborhoodBL
    {
        Task<List<TblNeighborhoods>> GetAllNeighborhoodsAsync();
        Task<TblNeighborhoods> GetNeighborhoodByIdAsync(int id);
        Task AddNeighborhoodAsync(TblNeighborhoods s);
        Task UpdateNeighborhoodAsync(TblNeighborhoods s);
        Task DeleteNeighborhoodAsync(int id);
    }
}
