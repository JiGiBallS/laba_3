using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.DAL.Entities
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }

        public string Title { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Price { get; set; }
        public string Manufacturer { get; set; }

    }
}