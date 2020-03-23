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
        public string Parameter { get; set; }
    }
}