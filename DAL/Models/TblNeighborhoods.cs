using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TblNeighborhoods
    {
        public TblNeighborhoods()
        {
            TblCustomers = new HashSet<TblCustomers>();
            TblStations = new HashSet<TblStations>();
            TblStreets = new HashSet<TblStreets>();
        }

        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }

        public virtual ICollection<TblCustomers> TblCustomers { get; set; }
        public virtual ICollection<TblStations> TblStations { get; set; }
        public virtual ICollection<TblStreets> TblStreets { get; set; }
    }
}
