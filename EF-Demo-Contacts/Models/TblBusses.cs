using System;
using System.Collections.Generic;

namespace EF_Demo_Contacts.Models
{
    public partial class TblBusses
    {
        public TblBusses()
        {
            TblBoringBussesForTravels = new HashSet<TblBoringBussesForTravels>();
        }

        public string CmBus { get; set; }
        public int SeveralPlaces { get; set; }
        public string Company { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<TblBoringBussesForTravels> TblBoringBussesForTravels { get; set; }
    }
}
