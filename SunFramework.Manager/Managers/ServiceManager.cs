using AspectCore.Configuration;
using AspectCore.DynamicProxy.Parameters;
using AspectCore.Extensions.Autofac;
using Autofac;
using SunFramework.Interface.Manager;
using SunFramework.Interface.Model;
using SunFramework.Interface.Repository;
using SunFramework.Manager.Abstraction;
using SunFramework.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Manager
{
    public class ServiceManager : IServiceManager
    {
        IServiceRepository serviceRepository { get; set; }

        private ContainerBuilder CreateBuilder()
        {
            return new ContainerBuilder().RegisterDynamicProxy(config =>
            {
                config.Interceptors.AddDelegate(next => ctx => next(ctx), Predicates.ForNameSpace("SunFramework.Manager"));
            });
        }

        public ServiceManager()
        {
            var builder = CreateBuilder();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>();
            var container = builder.Build();
            serviceRepository = container.Resolve<IServiceRepository>();
        }

        public ICollection<IServiceModel> GetActiveServices()
        {
            return serviceRepository.GetActiveServices().ToList();
        }

        public IServiceModel UpdateService(IServiceModel model)
        {
            return serviceRepository.Update(model.ServiceId, model);
        }
    }
}
