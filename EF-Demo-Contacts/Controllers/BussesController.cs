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
    public class BussesController : ControllerBase
    {
        IBusBL busBL;

        public BussesController(IBusBL _busBL)
        {
            this.busBL = _busBL;
        }

        [HttpPost("AddBus")]
        public async Task<List<TblBusses>> AddBusAsync(TblBusses b)
        {
            await this.busBL.AddBusAsync(b);
            return await busBL.GetAllBussesAsync();
        }

        [HttpDelete("DeleteBus/{cmBus}")]
        public async Task<List<TblBusses>> DeleteBusAsync(string cmBus)
        {
            await this.busBL.DeleteBusAsync(cmBus);
            return await this.busBL.GetAllBussesAsync();
        }

        [HttpGet("GetAllBusses")]
        public async Task<List<TblBusses>> GetAllSBussesAsync()
        {
            return await this.busBL.GetAllBussesAsync();
        }

        [HttpGet("GetBusByCmBus/{cmBus}")]
        public async Task<TblBusses> GetBusByCmBusAsync(string cmBus)
        {
            return await this.busBL.GetBusByCmBusAsync(cmBus);
        }

        [HttpPut("UpdateBus")]
        public async Task<List<TblBusses>> UpdateBusAsync(TblBusses b)
        {
            await this.busBL.UpdateBusAsync(b);
            return await this.busBL.GetAllBussesAsync();
        }
    }
}
