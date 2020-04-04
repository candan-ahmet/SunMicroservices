using SunFramework.Interface.Manager;
using SunFramework.Interface.Model;
using SunFramework.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackableEntities;

namespace SunFramework.Interface.UnitOfWork
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
