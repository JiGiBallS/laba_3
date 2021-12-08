using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        public string NameCategory { get; set; }
    }
}