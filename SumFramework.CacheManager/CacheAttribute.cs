using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Newtonsoft.Json.Linq;
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
                context.ReturnValue = cacheManager.GetCacheValue(mainKey, key, cacheMinute);
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

    public class CacheArrayAttribute : AbstractInterceptorAttribute
    {
        private int cacheMinute;
        private string uniqColumn;
        ICacheManager cacheManager;

        public CacheArrayAttribute(string uniqColumn, int cacheTime = 360)
        {
            this.uniqColumn = uniqColumn;
            cacheMinute = cacheTime;
            cacheManager = new CacheManager();
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            string mainKey = $"{context.ImplementationMethod.DeclaringType.FullName}.{context.ProxyMethod.Name}";
            string key = string.Join("", context.GetParameters().Select(c => c.Type.Name + c.Value));
            if (cacheManager.ContainsKey(mainKey, key))
            {
                context.ReturnValue = cacheManager.GetCacheArrayValues(mainKey, key);
                return;
            }
            await next(context);
            var value = context.ReturnValue;
            if (value != null)
            {
                cacheManager.AddCacheArray(mainKey, key, value, uniqColumn);
            }
        }
    }


    public class CacheArrayUpdateAttribute : AbstractInterceptorAttribute
    {
        private string uniqColumn;
        ICacheManager cacheManager;

        public CacheArrayUpdateAttribute(string uniqColumn)
        {
            this.uniqColumn = uniqColumn;
            cacheManager = new CacheManager();
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            string mainKey = $"{context.ImplementationMethod.DeclaringType.FullName}.{context.ProxyMethod.Name}";
            string key = string.Join("", context.GetParameters().Select(c => c.Type.Name + c.Value));
            await next(context);
            var value = context.ReturnValue;
            if (value != null)
            {
                object uniqValue = JObject.FromObject(value)[uniqColumn];
                cacheManager.UpdateCacheArray(mainKey, key, value, uniqValue);
            }
        }
    }
}
