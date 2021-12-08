using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
              ErrorMessageResourceName = "OrdersIdRequired")]
        [Display(Name = "OrdersId", ResourceType = typeof(Resources.Resource))]
        public int OrdersId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
      ErrorMessageResourceName = "Name_customerRequired")]
        [Display(Name = "Name_customer", ResourceType = typeof(Resources.Resource))]
        public string Name_customer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
               ErrorMessageResourceName = "Surname_customerRequired")]
        [Display(Name = "Surname_customer", ResourceType = typeof(Resources.Resource))]
        public string Surname_customer { get; set; }
       
        [Column(TypeName = "date")]
        public DateTime Date_Order { get; set; }
      
     
        public int Amount { get; set; }
      
        public int Status { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "DateOfCompletionRequired")]
        [Display(Name = "DateOfCompletion", ResourceType = typeof(Resources.Resource))]
        [Column(TypeName = "date")]
        public DateTime DateOfCompletion { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                ErrorMessageResourceName = "MNumberRequired")]
        [Display(Name = "MNumber", ResourceType = typeof(Resources.Resource))]
        public string MNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                ErrorMessageResourceName = "EmailRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        public virtual ICollection<StockViewModel> Stocks { get; set; }
    }
}