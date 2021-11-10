using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITravelDAL
    {
        Task<List<TblTravels>> GetAllTravelsAsync();
        Task<TblTravels> GetTravelByIdAsync(int id);
        Task AddTravelAsync(TblTravels t);
        Task UpdateTravelAsync(TblTravels t);
        Task DeleteTravelAsync(int id);
    }
}
