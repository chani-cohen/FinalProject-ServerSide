using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblTypesOfUsers
    {
        public TblTypesOfUsers()
        {
            TblUsers = new HashSet<TblUsers>();
        }

        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<TblUsers> TblUsers { get; set; }
    }
}
