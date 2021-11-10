using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblTickets
    {
        public TblTickets()
        {
            TblBoringCustomersForBusses = new HashSet<TblBoringCustomersForBusses>();
            TblOrders = new HashSet<TblOrders>();
        }

        public int TicketId { get; set; }
        public int SiteId { get; set; }
        public int FromAge { get; set; }
        public int UntilAge { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }

        public virtual TblSites Site { get; set; }
        public virtual ICollection<TblBoringCustomersForBusses> TblBoringCustomersForBusses { get; set; }
        public virtual ICollection<TblOrders> TblOrders { get; set; }
    }
}
