using System;
using System.Linq;
using System.Reflection;
using SunFramework.Aspect.Extensions.Reflection;
using SunFramework.Aspect.DependencyInjection;
using SunFramework.Aspect.Utils;

namespace SunFramework.Aspect.DynamicProxy.Parameters
{
    public sealed class ParameterInterceptorSelector : IParameterInterceptorSelector
    {
        private readonly IPropertyInjectorFactory _propertyInjectorFactory;
        private readonly IAspectCaching _aspectCaching;

        public ParameterInterceptorSelector(IPropertyInjectorFactory propertyInjectorFactory, IAspectCachingProvider aspectCachingProvider)
        {
            if (aspectCachingProvider == null)
            {
                throw new ArgumentNullException(nameof(aspectCachingProvider));
            }
            _propertyInjectorFactory = propertyInjectorFactory ?? throw new ArgumentNullException(nameof(propertyInjectorFactory));
            _aspectCaching = aspectCachingProvider.GetAspectCaching(nameof(ParameterInterceptorSelector));
        }

        public IParameterInterceptor[] Select(ParameterInfo parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            return (IParameterInterceptor[])_aspectCaching.GetOrAdd(parameter, info =>
             {
                 var interceptors = ((ParameterInfo)info).GetReflector().GetCustomAttributes().OfType<IParameterInterceptor>().ToArray();
                 for (var i = 0; i < interceptors.Length; i++)
                 {
                     var interceptor = interceptors[i];
                     if (PropertyInjectionUtils.Required(interceptor))
                     {
                         _propertyInjectorFactory.Create(interceptor.GetType()).Invoke(interceptor);
                     }
                 }
                 return interceptors;
             });
        }
    }
}