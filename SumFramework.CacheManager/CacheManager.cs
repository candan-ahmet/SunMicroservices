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


        public void AddCacheArray(string mainKey, string key, object value, string uniqColumn)
        {
            CacheArrayStock.AddCache(mainKey, key, value, uniqColumn);
        }

        public void ClearCacheArray(string mainKey)
        {
            CacheArrayStock.ClearCache(mainKey);
        }

        public bool ContainsKeyArray(string mainKey, string key, object uniqValue)
        {
            return CacheArrayStock.ContainsKey(mainKey, key, uniqValue);
        }

        public object[] GetCacheArrayValues(string mainKey, string key)
        {
            ICollection<object> list = new Collection<object>();
            var result = CacheArrayStock.GetCacheValues(mainKey, key);
            foreach (var item in result)
                list.Add(item.Value.Value);
            return list.ToArray();
        }

        public object GetCacheArrayValue(string mainKey, string key, object uniqValue, int cacheMinute)
        {
            return CacheArrayStock.GetValue(mainKey, key, uniqValue, cacheMinute);
        }

        public void UpdateCacheArray(string mainKey, string key, object value, object uniqValue)
        {
            CacheArrayStock.UpdateCache(mainKey, key, value, uniqValue);
        }
    }
}
