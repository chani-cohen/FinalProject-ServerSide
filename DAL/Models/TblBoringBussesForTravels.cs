using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblBoringBussesForTravels
    {
        public TblBoringBussesForTravels()
        {
            TblBoringCustomersForBusses = new HashSet<TblBoringCustomersForBusses>();
        }

        public int BoringBussesId { get; set; }
        public int TravelId { get; set; }
        public string CmBus { get; set; }
        public int DriverId { get; set; }

        public virtual TblBusses CmBusNavigation { get; set; }
        public virtual TblDrivers Driver { get; set; }
        public virtual TblTravels Travel { get; set; }
        public virtual ICollection<TblBoringCustomersForBusses> TblBoringCustomersForBusses { get; set; }
    }
}
