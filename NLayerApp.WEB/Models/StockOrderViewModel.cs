using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class StockOrderViewModel
    {
        public List<StockViewModel> Stock { get; set; }
        public List<OrderViewModel> Order { get; set; }
    }
}