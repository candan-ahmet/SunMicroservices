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
        private static readonly IDictionary<string, ICacheObjectModel> cache = new Dictionary<string, ICacheObjectModel>();
        private static readonly IDictionary<string, IDictionary<object, DateTime>> cacheTime = new Dictionary<string, IDictionary<object, DateTime>>();
        private static readonly IDictionary<string, string> uniqColumns = new Dictionary<string, string>();

        public static object GetValue(string mainKey, object uniqValue, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey) && cacheTime.ContainsKey(mainKey) && cacheTime[mainKey].ContainsKey(uniqValue) && cacheTime[mainKey][uniqValue].AddMinutes(cacheMinute) >= DateTime.Now)
                foreach (var item in (dynamic)cache[mainKey])
                    if (item.GetType().GetProperty(GetCacheArrayUniqColumm(mainKey)).GetValue(item, null) == uniqValue)
                        return item;

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
            if (uniqColumns.ContainsKey(mainKey))
                uniqColumns[mainKey] = uniqColumn;
            else
                uniqColumns.Add(mainKey, uniqColumn);

            if (!ContainsKey(mainKey))
                cache.Add(mainKey, new CacheModel(value));
            else
                cache[mainKey] = new CacheModel(value);

            if (!cacheTime.ContainsKey(mainKey))
                cacheTime.Add(mainKey, new Dictionary<object, DateTime>());

            foreach (var item in (dynamic)value)
            {
                var uniqValue = item.GetType().GetProperty(uniqColumn).GetValue(item, null);
                if (!cacheTime[mainKey].ContainsKey(uniqValue))
                    cacheTime[mainKey].Add(uniqValue, DateTime.Now);
                else
                    cacheTime[mainKey][uniqValue] = DateTime.Now;
            }
        }

        public static void UpdateCache(string mainKey, object itemValue, object uniqValue)
        {
            if (cache.ContainsKey(mainKey) && cacheTime.ContainsKey(mainKey) && cacheTime[mainKey].ContainsKey(uniqValue))
            {
                cacheTime[mainKey][uniqValue] = DateTime.Now;
                var value = (dynamic)cache[mainKey].Value;
                for (int i = 0; i < value.Count; i++)
                    if (uniqValue.ToString() == value[i].GetType().GetProperty(GetCacheArrayUniqColumm(mainKey)).GetValue(value[i]).ToString())
                    {
                        if (value[i] != itemValue)
                            foreach (var prop in itemValue.GetType().GetProperties())
                                itemValue.GetType().GetProperty(prop.Name).SetValue(value[i], itemValue.GetType().GetProperty(prop.Name).GetValue(itemValue));
                        return;
                    }
            }
        }

        public static object GetCacheValues(string mainKey, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey) && cache[mainKey].CacheDate.AddMinutes(cacheMinute) >= DateTime.Now)
                return cache[mainKey].Value;

            return null;
        }

        public static void ClearCache(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                cache.Remove(mainKey);
        }
    }
}
