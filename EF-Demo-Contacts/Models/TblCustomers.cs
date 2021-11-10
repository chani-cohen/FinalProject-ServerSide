using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblCustomers
    {
        public TblCustomers()
        {
            TblBoringCustomersForBusses = new HashSet<TblBoringCustomersForBusses>();
            TblOrders = new HashSet<TblOrders>();
            TblUsers = new HashSet<TblUsers>();
        }

        public string Email { get; set; }
        public string LastName { get; set; }
        public int? StreetId { get; set; }
        public int? HouseNumber { get; set; }
        public int? NeighborhoodId { get; set; }
        public string Tel { get; set; }
        public string Phone { get; set; }

        public virtual TblNeighborhoods Neighborhood { get; set; }
        public virtual TblStreets Street { get; set; }
        public virtual ICollection<TblBoringCustomersForBusses> TblBoringCustomersForBusses { get; set; }
        public virtual ICollection<TblOrders> TblOrders { get; set; }
        public virtual ICollection<TblUsers> TblUsers { get; set; }
    }
}
