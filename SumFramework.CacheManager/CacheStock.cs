using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SunFramework.Interface.Manager.Model;
using System;
using System.Collections.Generic;
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
        private static readonly IDictionary<string, IDictionary<string, IDictionary<object, ICacheObjectModel>>> cache = new Dictionary<string, IDictionary<string, IDictionary<object, ICacheObjectModel>>>();
        
        public static object GetValue(string mainKey, string key, object uniqValue, int cacheMinute)
        {
            if (cache.ContainsKey(mainKey))
            {
                IDictionary<object, ICacheObjectModel> listModel;
                ICacheObjectModel model;
                if (cache[mainKey].TryGetValue(key, out listModel) && listModel.TryGetValue(uniqValue, out model) && model.CacheDate.AddMinutes(cacheMinute) >= DateTime.Now)
                    return listModel[uniqValue];
            }

            return null;
        }
       


        public static bool ContainsKey(string mainKey, string key, object uniqValue)
        {
            return cache.ContainsKey(mainKey) && cache[mainKey].ContainsKey(key) && cache[mainKey][key].ContainsKey(uniqValue);
        }

        public static void AddCache(string mainKey, string key, object value, string uniqColumn)
        {
            string jsonObject = JsonConvert.SerializeObject(value);
            if (jsonObject.Length > 0 && jsonObject[0] == '[')
            {
                JArray list = JArray.FromObject(value);
                IDictionary<object, ICacheObjectModel> cacheList = new Dictionary<object, ICacheObjectModel>();
                foreach (var item in list)
                    cacheList.Add(item[uniqColumn], new CacheModel(item));

                if (!cache.ContainsKey(mainKey))
                    cache.Add(mainKey, new Dictionary<string, IDictionary<object, ICacheObjectModel>>());

                var cacheValues = cache[mainKey];
                if (!cacheValues.ContainsKey(key))
                    cacheValues.Add(key, cacheList);
            }
        }

        public static void UpdateCache(string mainKey, string key, object value, object uniqValue)
        {
            if (ContainsKey(mainKey, key, uniqValue))
                cache[mainKey][key][uniqValue] = new CacheModel(value);
        }

        public static IDictionary<object, ICacheObjectModel> GetCacheValues(string mainKey, string key)
        {
            if (cache.ContainsKey(mainKey) && cache[mainKey].ContainsKey(key))
                return cache[mainKey][key];

            return null;
        }

        public static void ClearCache(string mainKey)
        {
            if (cache.ContainsKey(mainKey))
                cache[mainKey].Clear();
        }
    }
}
