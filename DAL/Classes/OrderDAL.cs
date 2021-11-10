using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Mail;

namespace DAL.Classes
{
    public class OrderDAL : IOrderDAL
    {
        TravelsContext db;

        public OrderDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddOrderAsync(TblOrders o)
        {
            //מערך ובו כל ההזמנות ללקוח זה
            var ordersOfThisCustomer = this.db.TblOrders.Where(o1 => o1.Email.Equals(o.Email)).Include(o => o.Ticket);
            Boolean degel = false;
            foreach (var order in ordersOfThisCustomer)
            {
                //בדיקה האם קיימת ללקוח זה הזמנה לאותה נסיעה עם אותו סוג כרטיס
                if (order.TravelId == o.TravelId && order.TicketId == o.TicketId)
                {
                    //במידה וכן עידכון הכמות והמחיר הכולל
                    order.Count += o.Count;
                    order.SumToPay += o.Count * order.Ticket.Price;
                    degel = true;
                }
            }
            //במידה ולא יצירת הזמנה חדשה ללקוח
            if (!degel)
                await this.db.TblOrders.AddAsync(o);
            //עידכון מסד הנתונים בכל מקרה
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            //מחיקת הזמנה שקיבלנו את הקוד שלה
            TblOrders o = await this.db.TblOrders.FirstOrDefaultAsync(o1 => o1.OrderId == id);

            //MailMessage mail = new MailMessage()
            //{
            //    From = new MailAddress("odaya1350@gmail.com"),
            //    Subject = "הנסיעה שנרשמת אליה בוטלה",
            //};
            //mail.To.Add(this.db.TblOrders.Where(o => o.OrderId == id).Select(o => o.Email).FirstOrDefault());
            //SmtpClient SmtpServer = new SmtpClient()
            //{
            //     Port = 587,
            //     Host = "smtp.gmail.com",
            //     DeliveryMethod = SmtpDeliveryMethod.Network,
            //     UseDefaultCredentials = false,
            //     Credentials = new System.Net.NetworkCredential("savebillsforyou@gmail.com", "save1bills"),
            //     EnableSsl = true,
            //};
            //SmtpServer.Send(mail);‏       

            if (o != null)
            {
                o.Status = false;
                await this.db.SaveChangesAsync();
            }
        }

        public async Task DeleteOrdersByTravelIdAsync(int travelId)
        {
            //כל ההזמנות שהקוד נסיעה שלהן הוא הקוד שהתקבל
            var ordersToDelete = this.db.TblOrders.Where(o => o.TravelId == travelId);
            foreach (var order in ordersToDelete)
            {
                //מחיקת ההזמנה
                order.Status = false;
            }
            await this.db.SaveChangesAsync();
        }

        public async Task<List<TblOrders>> GetAllOrdersAsync()
        {
            return await this.db.TblOrders.Where(o => o.Status == true).ToListAsync();
        }

        //!!צריך לבדוק שישלפו רק ההזמנות לנסיעות שלא עברו עדיין גם מבחינת השעה
        public async Task<List<TblOrders>> GetOrderByEmailAsync(string email)
        {
            //DateTime d = DateTime.Now;
            //DateTime d2 = Convert.ToDateTime(this.db.TblOrders.Where(o => o.OrderId == 2).Select(o => o.Travel.TravelDate));
            var arr = await this.db.TblOrders
                .Where(o => o.Status == true && o.Email.Equals(email) &&
            (o.Travel.TravelDate.Date > DateTime.Today.Date
            || o.Travel.TravelDate.Date == DateTime.Today.Date))
            //&& o.Travel.LeavingTime.Hours> DateTime.Today.Hour)))                 
                .Include(o => o.Ticket)
                .Include(o => o.Travel)
                       .ThenInclude(t => t.Site)
                .Include(o => o.Station)

                //מיון ההזמנות של הלקוח לפי תאריך הנסיעה
                .OrderBy(o => o.Travel.TravelDate)
                .ToListAsync<TblOrders>();
            return arr;
        }

        //!!צריך לבדוק שישלפו רק ההזמנות לנסיעות שלא עברו עדיין גם מבחינת השעה
        public async Task<List<TblOrders>> GetOrderByTravelIdAsync(int travelId)
        {
            var arr = await this.db.TblOrders
                .Where(o => o.Status == false && o.TravelId == travelId &&
            (o.Travel.TravelDate.Date > DateTime.Today.Date
            || o.Travel.TravelDate.Date == DateTime.Today.Date))
            //&& o.Travel.LeavingTime.Hours> DateTime.Today.Hour)))                 
                .Include(o => o.Ticket)
                .Include(o => o.Travel)
                .Include(o => o.EmailNavigation)    //אמור להציג את פרטי הלקוח
                                                    //.ThenInclude(t => t.Site)
                .Include(o => o.Station)

                //מיון ההזמנות של הלקוחות לפי תאריך הזמנה
                .OrderBy(o => o.OrderDate)
                .ToListAsync<TblOrders>();
            return arr;
        }

        //לעדכן לפי הטבלה החדשה
        public async Task UpdateOrderAsync(TblOrders o2)
        {
            TblOrders o = await this.db.TblOrders.Where(o => o.Status == true).FirstOrDefaultAsync(o1 => o1.OrderId == o2.OrderId);
            if (o != null)
            {
                o.SendMessageAboutStation = o2.SendMessageAboutStation;
                o.StationId = o2.StationId;
                o.SumToPay = o2.SumToPay;
                //לא ניתן לשנות תאריך להזמנה ולקוח להזמנה
            }
            await this.db.SaveChangesAsync();
        }
    }
}
