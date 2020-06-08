using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SunFramework.Interface.Manager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Cache
{
    public class CacheStock
    {
        private static readonly IDictionary<string, IDictionary<string, ICacheObjectModel>> cache = new Dictionary<string, IDictionary<string, ICacheObjectModel>>();

        public static object GetValue(string mainKey, string key, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey))
            {
                ICacheObjectModel model;
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

        public static void AddCache(string mainKey, string key, ICacheObjectModel value)
        {
            if (!cache.ContainsKey(mainKey))
                cache.Add(mainKey, new Dictionary<string, ICacheObjectModel>());

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

        public static IEnumerable<ICacheObjectModel> GetCacheValues(string mainKey)
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

    public class CacheArrayStock
    {
        private static readonly IDictionary<string, IDictionary<object, ICacheObjectModel>> cache = new Dictionary<string, IDictionary<object, ICacheObjectModel>>();
        private static readonly IDictionary<string, string> uniqColumns = new Dictionary<string, string>();

        public static object GetValue(string mainKey, object uniqValue, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey))
            {
                ICacheObjectModel model;
                if (cache[mainKey].TryGetValue(uniqValue, out model) && model.CacheDate.AddMinutes(cacheMinute) >= DateTime.Now)
                    return cache[mainKey][uniqValue];
            }

            return null;
        }

        public static string GetCacheArrayUniqColumm(string mainKey)
        {
            return uniqColumns.ContainsKey(mainKey) ? uniqColumns[mainKey] : string.Empty;
        }

        public static bool ContainsKey(string mainKey)
        {
            return cache.ContainsKey(mainKey);
        }

        public static void AddCache(string mainKey, object value, string uniqColumn)
        {
            if (!uniqColumns.ContainsKey(mainKey))
                uniqColumns.Add(mainKey, uniqColumn);

            IDictionary<object, ICacheObjectModel> cacheList = new Dictionary<object, ICacheObjectModel>();
            foreach (var item in (dynamic)value)
                cacheList.Add(item.GetType().GetProperty(uniqColumn).GetValue(item, null), new CacheModel(item));

            if (!cache.ContainsKey(mainKey))
                cache.Add(mainKey, new Dictionary<object, ICacheObjectModel>());

            foreach (var item in cacheList)
                cache[mainKey].Add(item);
        }

        public static void UpdateCache(string mainKey, object value, object uniqValue)
        {
            if (cache.ContainsKey(mainKey) && cache[mainKey].ContainsKey(uniqValue))
                cache[mainKey][uniqValue] = new CacheModel(value);
        }

        public static IDictionary<object, ICacheObjectModel> GetCacheValues(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                return cache[mainKey];

            return null;
        }

        public static void ClearCache(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                cache[mainKey].Clear();
        }
    }
}
