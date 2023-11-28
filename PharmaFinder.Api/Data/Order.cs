using System;
using System.Collections.Generic;

namespace PharmaFinder.Api.Data
{
    public partial class Order
    {
        public Order()
        {
            Ordermeds = new HashSet<Ordermed>();
        }

        public decimal Orderid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Pharmacyid { get; set; }
        public DateTime? Orderdate { get; set; }
        public string? Approval { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Orderprice { get; set; }

        public virtual ICollection<Ordermed> Ordermeds { get; set; }
    }
}
