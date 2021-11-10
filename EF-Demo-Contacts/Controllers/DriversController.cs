using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DriversController : ControllerBase
    {
        IDriverBL driverlBL;

        public DriversController(IDriverBL _driverlBL)
        {
            driverlBL = _driverlBL;
        }

        [HttpPost("AddDriver")]
        public async Task<List<TblDrivers>> AddDriverAsync(TblDrivers d)
        {
            await this.driverlBL.AddDriverAsync(d);
            return await driverlBL.GetAllDriversAsync();
        }

        [HttpDelete("DeleteDriver/{tz}")]
        public async Task<List<TblDrivers>> DeleteDriverAsync(string tz)
        {
            await this.driverlBL.DeleteDriverAsync(tz);
            return await driverlBL.GetAllDriversAsync();
        }

        [HttpGet("GetAllDrivers")]
        public async Task<List<TblDrivers>> GetAllDriversAsync()
        {
            return await this.driverlBL.GetAllDriversAsync();
        }

        [HttpGet("GetDriverByTz/{tz}")]
        public async Task<TblDrivers> GetDriverByTzAsync(string tz)
        {
            return await this.driverlBL.GetDriverBytzAsync(tz);
        }

        [HttpPut("UpdateDriver")]
        public async Task<List<TblDrivers>> UpdateDriverAsync(TblDrivers d)
        {
            await this.driverlBL.UpdateDriverAsync(d);
            return await this.driverlBL.GetAllDriversAsync();
        }
    }

}
