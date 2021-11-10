using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface ITravelBL
    {
        Task<List<TblTravels>> GetAllTravelsAsync();
        Task<TblTravels> GetTravelByIdAsync(int id);
        Task AddTravelAsync(TblTravels t);
        Task UpdateTravelAsync(TblTravels t);
        Task DeleteTravelAsync(int id);
    }
}
