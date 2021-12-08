using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class ProductsViewModel
    {
        [Key]
        public int ProductsId { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }

        public string Manufacturer { get; set; }
        public int Price { get; set; }
    }
}