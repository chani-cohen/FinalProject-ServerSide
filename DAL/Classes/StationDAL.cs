using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class StationDAL : IStationDAL
    {
        TravelsContext db;

        public StationDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public Task<List<TblStations>> GetAllStationsAsync()
        {
            return this.db.TblStations.OrderBy(s=> s.StationId).ToListAsync();
        }
    }
}
