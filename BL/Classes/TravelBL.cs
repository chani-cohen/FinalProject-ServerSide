using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using BL.Interfaces;
using DAL.Models;

namespace BL.Classes
{
    public class TravelBL : ITravelBL
    {

        ITravelDAL travelDAL;

        public TravelBL(ITravelDAL _travelDAL)
        {
            this.travelDAL = _travelDAL;
        }

        public async Task AddTravelAsync(TblTravels t)
        {
            await this.travelDAL.AddTravelAsync(t);
        }

        public async Task DeleteTravelAsync(int id)
        {
            await this.travelDAL.DeleteTravelAsync(id);
        }

        public async Task<List<TblTravels>> GetAllTravelsAsync()
        {
            return await this.travelDAL.GetAllTravelsAsync();
        }

        public async Task<TblTravels> GetTravelByIdAsync(int id)
        {
            return await this.travelDAL.GetTravelByIdAsync(id);
        }

        public async Task UpdateTravelAsync(TblTravels t)
        {
            await this.travelDAL.UpdateTravelAsync(t);
        }
    }
}
