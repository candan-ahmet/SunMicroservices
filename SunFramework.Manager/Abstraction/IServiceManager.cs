using Autofac;
using SunFramework.Cache;
using SunFramework.Interface.Manager;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Manager.Abstraction
{
    public interface IServiceManager : IManager
    {
        [Cache]
        ICollection<IServiceModel> GetActiveServices();
    }
}
