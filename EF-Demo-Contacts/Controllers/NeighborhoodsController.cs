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
    public class NeighborhoodsController : ControllerBase
    {
        INeighborhoodBL neighborhoodBL;

        public NeighborhoodsController(INeighborhoodBL _neighborhoodBL)
        {
            neighborhoodBL = _neighborhoodBL;
        }

        [HttpPost("AddNeighborhood")]
        public async Task<List<TblNeighborhoods>> AddNeighborhoodAsync(TblNeighborhoods n)
        {
            await this.neighborhoodBL.AddNeighborhoodAsync(n);
            return await neighborhoodBL.GetAllNeighborhoodsAsync();
        }

        [HttpDelete("DeleteNeighborhood/{id}")]
        public async Task<List<TblNeighborhoods>> DeleteNeighborhoodAsync(int id)
        {
            await this.neighborhoodBL.DeleteNeighborhoodAsync(id);
            return await neighborhoodBL.GetAllNeighborhoodsAsync();
        }

        [HttpGet("GetAllNeighborhoods")]
        public async Task<List<TblNeighborhoods>> GetAllNeighborhoodsAsync()
        {
            return await this.neighborhoodBL.GetAllNeighborhoodsAsync();
        }

        [HttpGet("GetNeighborhoodById/{id}")]
        public async Task<TblNeighborhoods> GetNeighborhoodByIdAsync(int id)
        {
            return await this.neighborhoodBL.GetNeighborhoodByIdAsync(id);
        }

        [HttpPut("UpdateNeighborhood")]
        public async Task<List<TblNeighborhoods>> UpdateSiteAsync(TblNeighborhoods n)
        {
            await this.neighborhoodBL.UpdateNeighborhoodAsync(n);
            return await this.neighborhoodBL.GetAllNeighborhoodsAsync();
        }
    }
}
