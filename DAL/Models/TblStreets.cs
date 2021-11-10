using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblStreets
    {
        public TblStreets()
        {
            TblCustomers = new HashSet<TblCustomers>();
            TblStations = new HashSet<TblStations>();
        }

        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public int? NeighborhoodId { get; set; }

        public virtual TblNeighborhoods Neighborhood { get; set; }
        public virtual ICollection<TblCustomers> TblCustomers { get; set; }
        public virtual ICollection<TblStations> TblStations { get; set; }
    }
}
