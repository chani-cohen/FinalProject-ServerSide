using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Interfaces
{
    public interface ITicketBL
    {
        Task<List<TblTickets>> GetAllTicketsAsync();
        Task<TblTickets> GetTicketByIdAsync(int id);
        Task<List<TblTickets>> GetTicketByIdSiteAsync(int idSite);
        Task AddTicketAsync(TblTickets t);
        Task UpdateTicketAsync(TblTickets t);
        Task DeleteTicketAsync(int id);
    }
}
