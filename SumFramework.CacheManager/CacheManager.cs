using SunFramework.Interface.Manager;
using SunFramework.Interface.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Cache
{
    public class CacheManager : ICacheManager
    {
        public void AddCache(string mainKey, string key, object value)
        {
            CacheStock.AddCache(mainKey, key, value);
        }

        public void AddCache(string mainKey, string key, ICacheModel value)
        {
            CacheStock.AddCache(mainKey, key, value);
        }

        public void ClearCache(string mainKey)
        {
            CacheStock.ClearCache(mainKey);
        }

        public bool ContainsKey(string mainKey, string key)
        {
            return CacheStock.ContainsKey(mainKey, key);
        }

        public IEnumerable<ICacheModel> GetCacheValues(string mainKey)
        {
            return CacheStock.GetCacheValues(mainKey);
        }

        public object GetValue(string mainKey, string key, int cacheMinute)
        {
            return CacheStock.GetValue(mainKey, key, cacheMinute);
        }

        public void UpdateCache(string mainKey, string key, object value)
        {
            CacheStock.UpdateCache(mainKey, key, value);
        }
    }
}
