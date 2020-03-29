using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumFramework.Cache
{
    public class CacheManager
    {
        private static readonly IDictionary<string, IDictionary<string, CacheModel>> cache = new Dictionary<string, IDictionary<string, CacheModel>>();

        public static object GetValue(string mainKey, string key, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey))
            {
                CacheModel model;
                if (cache[mainKey].TryGetValue(key, out model) && model.CacheDate.AddMinutes(cacheMinute) >= DateTime.Now)
                    return cache[mainKey][key].Value;
            }

            return null;
        }

        public static bool ContainsKey(string mainKey, string key)
        {
            return cache.ContainsKey(mainKey) && cache[mainKey].ContainsKey(key);
        }

        public static void AddCache(string mainKey, string key, object value)
        {
            AddCache(mainKey, key, new CacheModel(value));
        }

        public static void AddCache(string mainKey, string key, CacheModel value)
        {
            if (!cache.ContainsKey(mainKey))
                cache.Add(mainKey, new Dictionary<string, CacheModel>());

            var cacheValues = cache[mainKey];
            if (!cacheValues.ContainsKey(key))
                cacheValues.Add(key, value);
        }

        public static void UpdateCache(string mainKey, string key, object value)
        {
            if (cache.ContainsKey(mainKey))
            {
                var cacheValues = cache[mainKey];
                if (cacheValues.ContainsKey(key))
                    cacheValues[key] = new CacheModel(value);
            }
        }

        public static IEnumerable<CacheModel> GetCacheValues(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                return cache[mainKey].Values;

            return null;
        }

        public static void ClearCache(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                cache[mainKey].Clear();
        }
    }
}
