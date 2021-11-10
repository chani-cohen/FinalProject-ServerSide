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

    public class TravelsController : ControllerBase
    {
        ITravelBL travelBL;

        public TravelsController(ITravelBL _travelBL)
        {
            travelBL = _travelBL;
        }

        [HttpPost("AddTravel")]
        public async Task<List<TblTravels>> AddTravelAsync(TblTravels t)
        {
            await this.travelBL.AddTravelAsync(t);
            return await travelBL.GetAllTravelsAsync();
        }

        [HttpDelete("DeleteTravel/{id}")]
        public async Task<List<TblTravels>> DeleteTravelAsync(int id)
        {
            await this.travelBL.DeleteTravelAsync(id);
            return await this.travelBL.GetAllTravelsAsync();
        }

        [HttpGet("GetAllTravels")]
        public async Task<List<TblTravels>> GetAllTravelsAsync()
        {
            return await this.travelBL.GetAllTravelsAsync();
        }

        [HttpGet("GetTravelById/{id}")]
        public async Task<TblTravels> GetTravelByIdAsync(int id)
        {
            return await this.travelBL.GetTravelByIdAsync(id);
        }

        [HttpPut("UpdateTravel")]
        public async Task<List<TblTravels>> UpdateTravelAsync(TblTravels t)
        {
            await this.travelBL.UpdateTravelAsync(t);
            return await this.travelBL.GetAllTravelsAsync();
        }
    }
}
