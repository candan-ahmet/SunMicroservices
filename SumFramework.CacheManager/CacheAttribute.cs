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
        private readonly IDictionary<string, CacheModel> cache = new Dictionary<string, CacheModel>();

        private int cacheMinute;

        public CacheAttribute(int cacheTime = 360)
        {
            cacheMinute = cacheTime;
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            string key = string.Join("", context.GetParameters().Select(c => c.Type.Name + c.Value));
            var parameters = context.GetParameters();
            CacheModel cacheModel;
            if (cache.TryGetValue(key, out cacheModel) && cacheModel.CacheDate.AddMinutes(cacheMinute) >= DateTime.Now)
            {
                context.ReturnValue = cacheModel.Value;
                return;
            }
            await next(context);
            var value = context.ReturnValue;
            if (value != null)
            {
                cache[key] = new CacheModel(value);
            }
        }
    }
}
