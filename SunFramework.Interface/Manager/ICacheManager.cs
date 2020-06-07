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
        object GetValue(string mainKey, string key, int cacheMinute);
        bool ContainsKey(string mainKey, string key);
        void AddCache(string mainKey, string key, object value);
        void AddCache(string mainKey, string key, ICacheModel value);
        void UpdateCache(string mainKey, string key, object value);
        IEnumerable<ICacheModel> GetCacheValues(string mainKey);
        void ClearCache(string mainKey);
    }
}
