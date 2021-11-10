using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblTravels
    {
        public TblTravels()
        {
            TblBoringBussesForTravels = new HashSet<TblBoringBussesForTravels>();
            TblBoringCustomersForBusses = new HashSet<TblBoringCustomersForBusses>();
            TblOrders = new HashSet<TblOrders>();
        }

        public int TravelId { get; set; }
        public int SiteId { get; set; }
        public DateTime TravelDate { get; set; }
        public TimeSpan LeavingTime { get; set; }
        public TimeSpan ReturnTime { get; set; }
        public bool Status { get; set; }
        public int MaximunNumberOfPlaces { get; set; }

        public virtual TblSites Site { get; set; }
        public virtual ICollection<TblBoringBussesForTravels> TblBoringBussesForTravels { get; set; }
        public virtual ICollection<TblBoringCustomersForBusses> TblBoringCustomersForBusses { get; set; }
        public virtual ICollection<TblOrders> TblOrders { get; set; }
    }
}
