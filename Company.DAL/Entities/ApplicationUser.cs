using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NLayerApp.DAL.Entities
{        
        public class ApplicationUser : IdentityUser
        {
            public virtual ClientProfile ClientProfile { get; set; }
        }
}