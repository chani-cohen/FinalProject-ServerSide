using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface IStationBL
    {
        Task<List<TblStations>> GetAllStationsAsync();
    }
}
