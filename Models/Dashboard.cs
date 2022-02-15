using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_OJT.Models
{
    public class Dashboard
    {
        public decimal todaySale { get; set; }
        public decimal monthSale { get; set; }
        public decimal yearSale{get; set; }

        public decimal totalSale { get; set; }
        public decimal weekSale { get; set; }

        public int sale_id { get; set; }

        public decimal sale_amount { get; set; }
    }
}