using System;
using SunFramework.Aspect.Configuration;
using SunFramework.Aspect.DynamicProxy;
using SunFramework.Aspect.Extensions.AspectScope;
using SunFramework.Aspect.Extensions.AspNetCore.Filters;
using SunFramework.Aspect.Extensions.DataAnnotations;
using SunFramework.Aspect.Extensions.DataValidation;
using SunFramework.Aspect.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SunFramework.Aspect.Extensions.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspectScope(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.Replace(ServiceDescriptor.Scoped<IAspectScheduler, ScopeAspectScheduler>());
            services.Replace(ServiceDescriptor.Scoped<IAspectContextFactory, ScopeAspectContextFactory>());
            services.Replace(ServiceDescriptor.Scoped<IAspectBuilderFactory, ScopeAspectBuilderFactory>());
            return services;
        }

        public static IServiceCollection AddDataAnnotations(this IServiceCollection services, params AspectPredicate[] predicates)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.Replace(ServiceDescriptor.Transient<IDataValidator, AnnotationDataValidator>());
            services.Replace(ServiceDescriptor.Transient<IPropertyValidator, AnnotationPropertyValidator>());     
            services.TryAddTransient<IDataStateFactory, DataStateFactory>();
            services.ConfigureDynamicProxy(config =>
            {
                config.Interceptors.AddTyped<DataValidationInterceptorAttribute>(predicates);
                config.Interceptors.AddTyped<ModelBindingAdapterAttribute>(predicates);
            });
            services.AddMvc(config =>
            {
                config.Filters.Add<ModelStateAdapterAttribute>();
            });
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHttpContextFactory, HttpContextFactory>();
            return services;
        }
    }
}