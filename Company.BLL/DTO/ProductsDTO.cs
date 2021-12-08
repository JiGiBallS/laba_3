using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.BLL.DTO
{
    public class ProductsDTO
    {
        public int ProductsId { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public Stock Stock { get; set; }
    }
}