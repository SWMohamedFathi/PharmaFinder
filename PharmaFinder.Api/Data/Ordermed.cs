using System;
using System.Collections.Generic;

namespace PharmaFinder.Api.Data
{
    public partial class Ordermed
    {
        public decimal Ordermedid { get; set; }
        public decimal? Medicineid { get; set; }
        public decimal? Orderid { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Order? Order { get; set; }
    }
}
