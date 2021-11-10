using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class SiteDAL : ISiteDAL
    {
        TravelsContext db;

        public SiteDAL(TravelsContext _db)
        {
            this.db = _db;      
        }
        public async Task AddSiteAsync(TblSites s)
        {
            //בדיקה את שם האתר קיים כבר בסטטוס false
            TblSites site = await this.db.TblSites.FirstOrDefaultAsync(s1 => s1.NameSite.Equals(s.NameSite));
            //אם נמצא אתר בשם של האתר החדש להוספה - בדיקה מה הסטטוס שלו
            if (site != null)
            {
                if (site.Status == false)
                    site.Status = true;
                else   //אם האתר קיים בסטטוס פעיל לא תתבצע הוספה נוספת
                    return;
            }
            //במקרה ושם האתר לא קיים במסד הנתונים נשמור אותו
            else
                await this.db.TblSites.AddAsync(s);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteSiteAsync(int id)
        {
            //לבדוק מקרה שבו רוצים למחוק אתר ויש לו נסיעות עתידיות ולא לאפשר את זה
            TblSites s = await this.db.TblSites.FirstOrDefaultAsync(s1 => s1.SiteId == id);
            if (s != null) {
                s.Status = false;
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblSites>> GetAllSitesAsync()
        {
            return await this.db.TblSites.Where(s=> s.Status==true).ToListAsync();
        }

        public async Task<TblSites> GetSiteByIdAsync(int id)
        {
            return await this.db.TblSites.Where(s => s.Status == true).FirstOrDefaultAsync(s => s.SiteId == id);
        }

        public async Task UpdateSiteAsync(TblSites s1)
        {
            TblSites s = await this.db.TblSites.FirstOrDefaultAsync(s2 => s2.SiteId == s1.SiteId);
            if (s != null)
            {
                s.NameSite = s1.NameSite;
                s.Status = s1.Status;
                //s.TblTickets = s1.TblTickets;
                //s.TblTravels = s1.TblTravels;
            }
            await this.db.SaveChangesAsync();
        }
    }
}
