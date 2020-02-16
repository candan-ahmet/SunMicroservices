using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Service
{
    public interface IService1
    {
        JObject GetSingle(JObject key);
        JArray Get(JObject key);
        JObject Post(JObject item);
        JObject Put(JObject item);
        JObject Delete(JObject item);
    }
}
