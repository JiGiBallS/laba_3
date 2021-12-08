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
    public class ToOrderViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "ProductsIdRequired")]
        [Display(Name = "ProductsId", ResourceType = typeof(Resources.Resource))]
        public int ProductsId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "TitleRequired")]
        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_delivery { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
         ErrorMessageResourceName = "Category")]
        [Display(Name = "Category", ResourceType = typeof(Resources.Resource))]
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "PriceRequired")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public int Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "ManufacturerRequired")]
        [Display(Name = "Manufacturer", ResourceType = typeof(Resources.Resource))]
        public string Manufacturer { get; set; }
    }
}