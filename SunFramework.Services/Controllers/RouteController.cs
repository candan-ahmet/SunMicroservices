using SunFramework.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SunFramework.Services.Controllers
{
    public class RouteController : ApiController
    {
        [HttpGet]
        public ResponseModel Get()
        {
            var requestHeader = getRequestHeader();
            return new ResponseModel();
        }

        [HttpGet]
        public ResponseModel Get(string parameter)
        {
            var requestHeader = getRequestHeader();
            return new ResponseModel();
        }

        [HttpPost]
        public ResponseModel Post(RequestModel data)
        {
            var requestHeader = getRequestHeader();
            return new ResponseModel();
        }

        [HttpPut]
        public ResponseModel Put(RequestModel data)
        {
            var requestHeader = getRequestHeader();
            return new ResponseModel();
        }

        [HttpDelete]
        public ResponseModel Delete(RequestModel data)
        {
            var requestHeader = getRequestHeader();
            return new ResponseModel();
        }

        private RequestHeader getRequestHeader()
        {
            var values = Request.GetRouteData().Values;
            if (values.Keys.Contains("controllername") && values.Keys.Contains("servicename"))
                return null;
            return new RequestHeader
            {
                ControllerName = values["controllername"].ToString(),
                Parameter = values.Keys.Contains("parameter") ? values["parameter"].ToString() : string.Empty,
                ServiceName = values["servicename"].ToString()
            };
        }
    }
}
