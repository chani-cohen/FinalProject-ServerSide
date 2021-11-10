using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblOrders
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public int TicketId { get; set; }
        public int TravelId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? StationId { get; set; }
        public bool? SendMessageAboutStation { get; set; }
        public int Count { get; set; }
        public int? SumToPay { get; set; }
        public bool Status { get; set; }

        public virtual TblCustomers EmailNavigation { get; set; }
        public virtual TblStations Station { get; set; }
        public virtual TblTickets Ticket { get; set; }
        public virtual TblTravels Travel { get; set; }
    }
}
