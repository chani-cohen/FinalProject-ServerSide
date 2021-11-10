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

    public class TicketsController : ControllerBase
    {
        ITicketBL ticketBL;

        public TicketsController(ITicketBL _ticketBL)
        {
            ticketBL = _ticketBL;
        }

        [HttpPost("AddTicket")]
        public async Task<List<TblTickets>> AddTicketAsync(TblTickets t)
        {
            await this.ticketBL.AddTicketAsync(t);
            return await this.ticketBL.GetTicketByIdSiteAsync(t.SiteId);
            //return await ticketBL.GetAllTicketsAsync();
        }

        [HttpDelete("DeleteTicket/{id}")]
        public async Task<List<TblTickets>> DeleteTicketAsync(int id)
        {
            await this.ticketBL.DeleteTicketAsync(id);
            return await ticketBL.GetAllTicketsAsync();
        }

        [HttpGet("GetAllTickets")]
        public async Task<List<TblTickets>> GetAllTicketsAsync()
        {
            return await this.ticketBL.GetAllTicketsAsync();
        }

        [HttpGet("GetTicketById/{id}")]
        public async Task<TblTickets> GetTicketByIdAsync(int id)
        {
            return await this.ticketBL.GetTicketByIdAsync(id);
        }

        [HttpGet("GetTicketByIdSite/{idSite}")]
        public async Task<List<TblTickets>> GetTicketByIdSiteAsync(int idSite)
        {
            return await this.ticketBL.GetTicketByIdSiteAsync(idSite);
        }

        [HttpPut("UpdateTicket")]
        public async Task<List<TblTickets>> UpdateTicketAsync(TblTickets t)
        {
            await this.ticketBL.UpdateTicketAsync(t);
            return await this.ticketBL.GetAllTicketsAsync();
        }
    }
}
