using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.DAL.Entities
{
    public class ToOrder
    {
        [Key]
        public int ProductsId { get; set; }

        public string Title { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_delivery { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }

    }
}
