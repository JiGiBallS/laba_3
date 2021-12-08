using NLayerApp.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace NLayerApp.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}