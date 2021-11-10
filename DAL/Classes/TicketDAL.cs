using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class TicketDAL : ITicketDAL
    {

        TravelsContext db;
        public TicketDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddTicketAsync(TblTickets t)
        {
            await this.db.TblTickets.AddAsync(t);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            //מציאת הכרטיס למחיקה
            TblTickets t = await this.db.TblTickets.FirstOrDefaultAsync(t1 => t1.TicketId == id);
            if (t != null)
            {
                //בדיקה אם יש לכרטיס הזה הזמנות עתידיות
                //אם כן לא תתאפשר מחיקה
                var orders = this.db.TblOrders.Where(o => o.TicketId == id && o.Travel.TravelDate.Date > DateTime.Today.Date).ToListAsync();
                //אם אין הזמנות עתידיות לכרטיס זה תתבצע מחיקתו
                if (orders == null)
                {
                    //מחיקת הכרטיס
                    t.Status = false;
                    await this.db.SaveChangesAsync();
                    //return true;
                }
            }
            //return false;

        }

        public async Task<List<TblTickets>> GetAllTicketsAsync()
        {
            return await this.db.TblTickets.Where(t => t.Status == true).OrderBy(t => t.Price).ToListAsync();
        }

        public async Task<TblTickets> GetTicketByIdAsync(int id)
        {
            return await this.db.TblTickets.Where(t => t.Status == true).FirstOrDefaultAsync(t => t.TicketId == id);
        }

        public async Task<List<TblTickets>> GetTicketByIdSiteAsync(int idSite)
        {
            return await this.db.TblTickets.Where(t => t.Status == true && t.SiteId == idSite).ToListAsync();
        }

        public async Task UpdateTicketAsync(TblTickets t1)
        {
            TblTickets t = await this.db.TblTickets.Where(t2 => t2.Status == true).FirstOrDefaultAsync(t2 => t2.TicketId == t1.TicketId);
            if (t != null)
            {
                t.FromAge = t1.FromAge;
                t.UntilAge = t1.UntilAge;
                t.Price = t1.Price;

                //אין לעדכן ולשנות אתר לכרטיס
                //רק טווח גילאים ומחיר
            }
            await this.db.SaveChangesAsync();
        }

        
    }
}
