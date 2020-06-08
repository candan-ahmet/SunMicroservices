using SunFramework.Interface.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Manager
{
    public interface ICacheManager : IManager
    {
        object GetCacheValue(string mainKey, string key, int cacheMinute);
        bool ContainsKey(string mainKey, string key);
        void AddCache(string mainKey, string key, object value);
        void AddCache(string mainKey, string key, ICacheObjectModel value);
        void UpdateCache(string mainKey, string key, object value);
        IEnumerable<ICacheObjectModel> GetCacheValues(string mainKey);
        void ClearCache(string mainKey);

        void AddCacheArray(string mainKey, object value, string uniqColumn);
        void ClearCacheArray(string mainKey);
        bool ContainsKeyArray(string mainKey);
        ICollection<object> GetCacheArrayValues(string mainKey);
        object GetCacheArrayValue(string mainKey, object uniqValue, int cacheMinute);
        void UpdateCacheArray(string mainKey, object value, object uniqValue);
        string CacheArrayUniqColumm(string mainKey);
    }
}
