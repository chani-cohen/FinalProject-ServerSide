using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblDrivers
    {
        public TblDrivers()
        {
            TblBoringBussesForTravels = new HashSet<TblBoringBussesForTravels>();
        }

        public int DriverId { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<TblBoringBussesForTravels> TblBoringBussesForTravels { get; set; }
    }
}
