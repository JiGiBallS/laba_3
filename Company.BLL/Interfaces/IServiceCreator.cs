using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}