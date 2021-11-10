using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
using BL.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL.Classes
{
    public class StationBL: IStationBL
    {
        IStationDAL stationDAL;

        public StationBL(IStationDAL _stationDAL)
        {
            this.stationDAL = _stationDAL;
        }

        public Task<List<TblStations>> GetAllStationsAsync()
        {
            return this.stationDAL.GetAllStationsAsync();
        }
    }
}
