using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DAL.Classes
{
    public class UserDAL: IUserDAL
    {
        TravelsContext db;

        public UserDAL(TravelsContext _db)
        {
            this.db = _db;
        }
        public async Task AddUserAsync(TblUsers u, TblCustomers c)
        {
            //Data Source=(localdb)\ProjectsV13;Initial Catalog=Travels;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            using (SqlConnection connection1 = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Travels;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection1.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection1.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = connection1.CreateCommand();
                command.Transaction = sqlTran;
                try
                {
                    //הוספת המשתמש החדש ופרטיו כלקוח עם שאר הפרטים הנוספים
                    await this.db.TblCustomers.AddAsync(c);

                    //הוספת המשתמש החדש
                    await this.db.TblUsers.AddAsync(u);
                    await this.db.SaveChangesAsync();

                    // Commit the transaction.
                    sqlTran.Commit();
                }
                catch (Exception)
                {
                    // Attempt to roll back the transaction.
                    sqlTran.Rollback();
                    //Console.WriteLine(e.Message);
                    //throw;
                }
            }
        }

        public async Task DeleteUserAsync(string email)
        {
            TblUsers u = await this.db.TblUsers.FirstOrDefaultAsync(u1 => u1.Email.Equals(email));
            if (u != null)
            {
                this.db.TblUsers.Remove(u);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<List<TblUsers>> GetAllUsersAsync()
        {
            return await this.db.TblUsers.ToListAsync();
        }

        public async Task<TblUsers> GetUserByEmailAsync(string email)
        {
            return await this.db.TblUsers.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task UpdateUserAsync(TblUsers u1)
        {
            TblUsers u = await this.db.TblUsers.FirstOrDefaultAsync(u2 => u2.Email.Equals(u1.Email));
            if (u != null)
            {
                u.Password = u1.Password;
                u.UserName = u1.UserName;
                u.UserTypeId = u1.UserTypeId;
                //u.UserType = u1.UserType;
            }
            await this.db.SaveChangesAsync();
        }
    }
}
