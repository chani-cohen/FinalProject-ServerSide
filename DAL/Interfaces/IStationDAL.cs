using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStationDAL
    {
        Task<List<TblStations>> GetAllStationsAsync();    
    }
}
