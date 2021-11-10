using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblBoringCustomersForBusses
    {
        public int BoringCustomersForBussesId { get; set; }
        public int BoringBussesId { get; set; }
        public int TravelId { get; set; }
        public string Email { get; set; }
        public int TicketId { get; set; }
        public int Count { get; set; }

        public virtual TblBoringBussesForTravels BoringBusses { get; set; }
        public virtual TblCustomers EmailNavigation { get; set; }
        public virtual TblTickets Ticket { get; set; }
        public virtual TblTravels Travel { get; set; }
    }
}
