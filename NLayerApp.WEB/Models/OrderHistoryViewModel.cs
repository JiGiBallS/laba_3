using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class OrderHistoryViewModel
    {
        [Key]
        public int OrdersId { get; set; }

        public string Name_customer { get; set; }

        public string Surname_customer { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_Order { get; set; }

        public int AllOrder { get; set; }

        public int Amount { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfCompletion { get; set; }

        public string MNumber { get; set; }

        public string Email { get; set; }

    }
}