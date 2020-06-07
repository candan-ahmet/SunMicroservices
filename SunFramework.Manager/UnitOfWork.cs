using Autofac;
using SunFramework.Interface.Manager;
using AspectCore.Extensions.Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspectCore.Configuration;
using SunFramework.Cache;
using SunFramework.Interface.Model;
using SunFramework.Manager.Abstraction;
using SunFramework.Interface.Repository;
using SunFramework.Repository.Identity;

namespace SunFramework.Manager
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserModel User { get; set; }
        public IEnumerable<IRoleModel> Roles { get; set; }
        public IEnumerable<IUserIdentityModel> UserIdentities { get; set; }

        private ContainerBuilder CreateBuilder()
        {
            return new ContainerBuilder().RegisterDynamicProxy(config =>
            {
                config.Interceptors.AddDelegate(next => ctx => next(ctx), Predicates.ForNameSpace("SunFramework.Manager"));
            });
        }

        public UnitOfWork()
        {
            var builder = CreateBuilder();
            builder.RegisterType<CacheManager>().As<ICacheManager>();
            builder.RegisterType<IdentityManager>().As<IIdentityManager>();
            builder.RegisterType<ServiceManager>().As<IServiceManager>();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>();
            var container = builder.Build();
            CacheManager = container.Resolve<ICacheManager>();
            IdentityManager = container.Resolve<IIdentityManager>();
            ServiceManager = container.Resolve<IServiceManager>();

        }

        public ICacheManager CacheManager { get; set; }
        public IIdentityManager IdentityManager { get; set; }
        public IServiceManager ServiceManager { get; set; }

        public void Dispose()
        {

        }
    }
}
