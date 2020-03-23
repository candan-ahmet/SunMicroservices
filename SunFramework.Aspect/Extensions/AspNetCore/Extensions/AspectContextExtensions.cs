using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SunFramework.Aspect.DynamicProxy
{
    public static class AspectContextExtensions
    {
        public static HttpContext GetHttpContext(this AspectContext aspectContext)
        {
            if (aspectContext == null)
            {
                throw new ArgumentNullException(nameof(aspectContext));
            }
            var httpContextAccessor = aspectContext.ServiceProvider.GetService<IHttpContextAccessor>();
            return httpContextAccessor?.HttpContext;
        }
    }
}
