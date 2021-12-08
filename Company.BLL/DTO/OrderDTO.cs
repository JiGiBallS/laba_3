using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.BLL.DTO
{
    public class OrderDTO
    {
        public int OrdersId { get; set; }

        public string Name_customer { get; set; }

        public string Surname_customer { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Order { get; set; }

        //[ForeignKey("Stock")]
        //public int? ProductsId { get; set; }
        //public Stock Stock { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfCompletion { get; set; }

        public int Amount { get; set; }

        public int Status { get; set; }


        public string MNumber { get; set; }

        public string Email { get; set; }

        public virtual ICollection<StockDTO> Stocks { get; set; }

    }
}