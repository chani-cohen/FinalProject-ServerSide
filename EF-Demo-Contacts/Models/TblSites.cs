using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblSites
    {
        public TblSites()
        {
            TblTickets = new HashSet<TblTickets>();
            TblTravels = new HashSet<TblTravels>();
        }

        public int SiteId { get; set; }
        public string NameSite { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<TblTickets> TblTickets { get; set; }
        public virtual ICollection<TblTravels> TblTravels { get; set; }
    }
}
