using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Interfaces;
using BL.Interfaces;
using System.Threading.Tasks;

namespace BL.Classes
{
    public class TicketBL : ITicketBL
    {
        ITicketDAL ticketDAL;

        public TicketBL(ITicketDAL _ticketDAL)
        {
            this.ticketDAL = _ticketDAL;
        }

        public async Task AddTicketAsync(TblTickets t)
        {
            await this.ticketDAL.AddTicketAsync(t);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await this.ticketDAL.DeleteTicketAsync(id);
        }

        public async Task<List<TblTickets>> GetAllTicketsAsync()
        {
            return await this.ticketDAL.GetAllTicketsAsync();
        }

        public async Task<TblTickets> GetTicketByIdAsync(int id)
        {
            return await this.ticketDAL.GetTicketByIdAsync(id);
        }

        public async Task<List<TblTickets>> GetTicketByIdSiteAsync(int idSite)
        {
            return await this.ticketDAL.GetTicketByIdSiteAsync(idSite);
        }

        public async Task UpdateTicketAsync(TblTickets t)
        {
            await this.ticketDAL.UpdateTicketAsync(t);
        }
    }
}
