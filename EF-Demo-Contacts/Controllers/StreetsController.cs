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
    public class StreetsController : ControllerBase
    {
        IStreetBL streetBL;

        public StreetsController(IStreetBL _streetBL)
        {
            this.streetBL = _streetBL;
        }

        [HttpPost("AddStreet")]
        public async Task<List<TblStreets>> AddStreetAsync(TblStreets s)
        {
            await this.streetBL.AddStreetAsync(s);
            return await streetBL.GetAllStreetsAsync();
        }

        [HttpDelete("DeleteStreet/{id}")]
        public async Task<List<TblStreets>> DeleteStreetAsync(int id)
        {
            await this.streetBL.DeleteStreetAsync(id);
            return await this.streetBL.GetAllStreetsAsync();
        }

        [HttpGet("GetAllStreets")]
        public async Task<List<TblStreets>> GetAllStreetsAsync()
        {
            return await this.streetBL.GetAllStreetsAsync();
        }

        [HttpGet("GetStreetById/{id}")]
        public async Task<TblStreets> GetStreetByIdAsync(int id)
        {
            return await this.streetBL.GetStreetByIdAsync(id);
        }

        [HttpPut("UpdateStreet")]
        public async Task<List<TblStreets>> UpdateStreetAsync(TblStreets s)
        {
            await this.streetBL.UpdateStreetAsync(s);
            return await this.streetBL.GetAllStreetsAsync();
        }
    }
}
