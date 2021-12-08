using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NLayerApp.BLL.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string NameCategory { get; set; }
    }
}