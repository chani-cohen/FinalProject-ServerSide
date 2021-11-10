using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace EF_Demo_Contacts
{
    public class DataOfUser
    {
        public TblUsers u;
        public TblCustomers c;

        public DataOfUser(TblUsers u, TblCustomers c)
        {
            this.u = u;
            this.c = c;
        }
    }
}
