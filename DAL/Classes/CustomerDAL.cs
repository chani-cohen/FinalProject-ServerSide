using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Classes
{
    public class CustomerDAL : ICustomerDAL
    {
        TravelsContext db;

        public CustomerDAL(TravelsContext _db)
        {
            this.db = _db;
        }

        public async Task AddCustomerAsync(TblCustomers c)
        {
            await this.db.TblCustomers.AddAsync(c);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(string email)
        {
            TblCustomers c = await this.db.TblCustomers.FirstOrDefaultAsync(c1 => c1.Email.Equals(email));
            if (c != null)
            {
                this.db.TblCustomers.Remove(c);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblCustomers>> GetAllCustomersAsync()
        {
            return await this.db.TblCustomers.ToListAsync();
        }

        public async Task<TblCustomers> GetCustomerByEmailAsync(string email)
        {
            return await this.db.TblCustomers.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }

        public async Task UpdateCustomerAsync(TblCustomers c2)
        {
            TblCustomers c = await this.db.TblCustomers.FirstOrDefaultAsync(c1 => c1.Email.Equals(c2.Email));
            if (c != null)
            {
                c.HouseNumber = c2.HouseNumber;
                c.LastName = c2.LastName;
                c.NeighborhoodId = c2.NeighborhoodId;
                c.Phone = c2.Phone;
                c.StreetId = c2.StreetId;
                c.Tel = c2.Tel;
                //לא ניתן לשנות קוד לקוח ומייל
            }
            await this.db.SaveChangesAsync();
        }
    }
}
