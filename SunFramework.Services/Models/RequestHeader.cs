using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunFramework.Services.Models
{
    public class RequestHeader
    {
        public string ServiceName { get; set; }
        public string ControllerName { get; set; }
        public string RequestMethod { get; set; }
        public string Parameter { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Parameters { get; set; }
        public List<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
    }
}