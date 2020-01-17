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
        IIdentityManager IdentityManager { get; set; }
        IServiceManager ServiceManager { get; set; }

        int SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        int? CommandTimeout { get; set; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
