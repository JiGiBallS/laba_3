using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
      
        public string NameCategory { get; set; }
 
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<ToOrder> ToOrders { get; set; }
        public Category()
        {
            Stocks = new  List<Stock>();
            ToOrders = new List<ToOrder>();
        }
    }
}