using SunFramework.Interface.Manager;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Manager.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IUserModel User { get; set; }
        IEnumerable<IRoleModel> Roles { get; set; }
        IEnumerable<IUserIdentityModel> UserIdentities { get; set; }

        IIdentityManager IdentityManager { get; set; }
        IServiceManager ServiceManager { get; set; }
        ICacheManager CacheManager { get; set; }
    }
}
