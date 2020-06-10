using SunFramework.Interface.Manager;
using SunFramework.Interface.Manager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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

        public void AddCache(string mainKey, string key, ICacheObjectModel value)
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

        public IEnumerable<ICacheObjectModel> GetCacheValues(string mainKey)
        {
            return CacheStock.GetCacheValues(mainKey);
        }

        public object GetCacheValue(string mainKey, string key, int cacheMinute)
        {
            return CacheStock.GetValue(mainKey, key, cacheMinute);
        }

        public void UpdateCache(string mainKey, string key, object value)
        {
            CacheStock.UpdateCache(mainKey, key, value);
        }


        public void AddCacheArray(string mainKey, object value, string uniqColumn)
        {
            CacheArrayStock.AddCache(mainKey, value, uniqColumn);
        }

        public void ClearCacheArray(string mainKey)
        {
            CacheArrayStock.ClearCache(mainKey);
        }

        public bool ContainsKeyArray(string mainKey)
        {
            return CacheArrayStock.ContainsKey(mainKey);
        }

        public object GetCacheArrayValues(string mainKey, int cacheMinute)
        {
            return CacheArrayStock.GetCacheValues(mainKey, cacheMinute);
        }

        public object GetCacheArrayValue(string mainKey, object uniqValue, int cacheMinute)
        {
            return CacheArrayStock.GetValue(mainKey, uniqValue, cacheMinute);
        }

        public void UpdateCacheArray(string mainKey, object value, object uniqValue)
        {
            CacheArrayStock.UpdateCache(mainKey, value, uniqValue);
        }

        public string CacheArrayUniqColumm(string mainKey)
        {
            return CacheArrayStock.GetCacheArrayUniqColumm(mainKey);
        }
    }
}
