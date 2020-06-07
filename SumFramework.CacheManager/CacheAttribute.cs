using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using SunFramework.Interface.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Cache
{
    public class CacheAttribute : AbstractInterceptorAttribute
    {
        private int cacheMinute;
        ICacheManager cacheManager;

        public CacheAttribute(int cacheTime = 360)
        {
            cacheMinute = cacheTime;
            cacheManager = new CacheManager();
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            string mainKey = $"{context.ImplementationMethod.DeclaringType.FullName}.{context.ProxyMethod.Name}";
            string key = string.Join("", context.GetParameters().Select(c => c.Type.Name + c.Value));
            if (cacheManager.ContainsKey(mainKey, key))
            {
                context.ReturnValue = cacheManager.GetValue(mainKey, key, cacheMinute);
                return;
            }
            await next(context);
            var value = context.ReturnValue;
            if (value != null)
            {
                cacheManager.AddCache(mainKey, key, value);
            }
        }
    }
}
