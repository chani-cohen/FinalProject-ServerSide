using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
//using System.Data.Entity;‏

namespace DAL.Classes
{
    public class TravelDAL : ITravelDAL
    {
        TravelsContext db;

        public TravelDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddTravelAsync(TblTravels t)
        {
            await this.db.TblTravels.AddAsync(t);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteTravelAsync(int id)
        {
            //מחיקת הנסיעה המבוקשת
            //לפני המחיקה - שליחת הודעת מייל לכל הנרשמים שהנסיעה בוטלה
            //לאפשר ביטול נסיעה רק 24 שעות קודם
            // דבר נוסף - מחיקת ההזמנות שקוד הנסיעה שלהם הוא הנסיעה הנוכחית -  טיפלנו בזה בפונקציה אחרת
            TblTravels t = await this.db.TblTravels.FirstOrDefaultAsync(t1 => t1.TravelId == id);
            if (t != null)
            {
                //מחיקת הנסיעה
                t.Status = false;
                await this.db.SaveChangesAsync();
            }
        }



        /// /////////////////////////////
        //!!צריך לבדוק שישלפו רק הנסיעות שלא עברו עדיין גם מבחינת השעה
        public async Task<List<TblTravels>> GetAllTravelsAsync()
        {
            ////////////include שימוש ב
            return await this.db.TblTravels.Where(t => t.Status == true && t.TravelDate.Date > DateTime.Today.Date)
                .Include(t => t.Site).OrderBy(t => t.TravelDate).ToListAsync();
        }


        public async Task<TblTravels> GetTravelByIdAsync(int id)
        {
            return await this.db.TblTravels.Where(t => t.Status == true).FirstOrDefaultAsync(t => t.TravelId == id);
        }

        public async Task UpdateTravelAsync(TblTravels t2)
        {
            TblTravels t = await this.db.TblTravels.Where(t => t.Status == true).FirstOrDefaultAsync(t1 => t1.TravelId == t2.TravelId);
            if (t != null)
            {
                t.LeavingTime = t2.LeavingTime;
                t.ReturnTime = t2.ReturnTime;
               // t.maximumNumberOfPlaces = t2.maximumNumberOfPlaces;
                //לא ניתן לשנות תאריך או יעד לנסיעה
            }
            await this.db.SaveChangesAsync();
        }
    }
}
