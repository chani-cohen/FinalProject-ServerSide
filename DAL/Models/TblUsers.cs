using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblUsers
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }

        public virtual TblCustomers EmailNavigation { get; set; }
        public virtual TblTypesOfUsers UserType { get; set; }
    }
}
