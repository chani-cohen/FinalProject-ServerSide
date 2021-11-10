using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        ISiteBL siteBL;

        public SitesController(ISiteBL _siteBL)
        {
            siteBL = _siteBL;
        }

        [HttpPost("AddSite")]
        public async Task<List<TblSites>> AddSiteAsync(TblSites s)
        {
            await this.siteBL.AddSiteAsync(s);
            return await siteBL.GetAllSitesAsync();
        }

        [HttpDelete("DeleteSite/{id}")]
        public async Task<List<TblSites>> DeleteSiteAsync(int id)
        {
            await this.siteBL.DeleteSiteAsync(id);
            return await siteBL.GetAllSitesAsync();
        }

        [HttpGet("GetAllSites")]
        public async Task<List<TblSites>> GetAllSitesAsync()
        {
            return await this.siteBL.GetAllSitesAsync();
        }

        [HttpGet("GetSiteById/{id}")]
        public async Task<TblSites> GetSiteByIdAsync(int id)
        {
            return await this.siteBL.GetSiteByIdAsync(id);
        }

        [HttpPut("UpdateSite")]
        public async Task<List<TblSites>> UpdateSiteAsync(TblSites s)
        {
            await this.siteBL.UpdateSiteAsync(s);
            return await this.siteBL.GetAllSitesAsync();
        }

    }
}

