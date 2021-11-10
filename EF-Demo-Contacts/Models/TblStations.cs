using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblStations
    {
        public TblStations()
        {
            TblOrders = new HashSet<TblOrders>();
        }

        public int StationId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string StationAddress { get; set; }
        public int? StreetId { get; set; }

        public virtual TblNeighborhoods Neighborhood { get; set; }
        public virtual TblStreets Street { get; set; }
        public virtual ICollection<TblOrders> TblOrders { get; set; }
    }
}
