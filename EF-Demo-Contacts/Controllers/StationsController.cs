using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Classes;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Classes;
using DAL.Models;
//בשביל חיבור צד הקליינט והסרבר
using Microsoft.AspNetCore.Cors;

namespace EF_Demo_Contacts.Controllers
{
    //בשביל חיבור צד הקליינט והסרבר
    [EnableCors()]

    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        IStationBL stationBL;

        public StationsController(IStationBL _stationBL)
        {
            this.stationBL = _stationBL;
        }

        [HttpGet("GetAllStations")]
        public async Task<List<TblStations>> GetAllStationsAsync()
        {
            return await this.stationBL.GetAllStationsAsync();
        }
    }
}
