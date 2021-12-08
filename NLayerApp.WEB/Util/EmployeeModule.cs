using Ninject.Modules;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.WEB.Util
{
    public class EmployeeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}
