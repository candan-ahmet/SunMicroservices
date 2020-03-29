using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumFramework.Cache
{
    public class CacheAttribute : AbstractInterceptorAttribute
    {
        private int cacheMinute;

        public CacheAttribute(int cacheTime = 360)
        {
            cacheMinute = cacheTime;
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            string mainKey = $"{context.ImplementationMethod.DeclaringType.FullName}.{context.ProxyMethod.Name}";
            string key = string.Join("", context.GetParameters().Select(c => c.Type.Name + c.Value));
            if (CacheManager.ContainsKey(mainKey, key))
            {
                context.ReturnValue = CacheManager.GetValue(mainKey, key, cacheMinute);
                return;
            }
            await next(context);
            var value = context.ReturnValue;
            if (value != null)
            {
                CacheManager.AddCache(mainKey, key, value);
            }
        }
    }
}
