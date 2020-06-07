using Newtonsoft.Json.Linq;
using RestSharp;
using SunFramework.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;

namespace SunFramework.Services.Controllers
{
    public class RouteController : ApiController
    {


        [HttpGet]
        public IRestResponse Get()
        {
            return getRequest();
        }

        [HttpPost]
        public IRestResponse Post(JObject data)
        {
            return getRequest();
        }

        [HttpPut]
        public IRestResponse Put(JObject data)
        {
            return getRequest();
        }

        [HttpDelete]
        public IRestResponse Delete(string param)
        {
            return getRequest();
        }

        [HttpDelete]
        public IRestResponse Delete(JObject data)
        {
            return getRequest();
        }

        private IRestResponse getRequest()
        {
            ResponseModel result = new ResponseModel();
            var values = Request.GetRouteData().Values;
            var headers = Request.Headers.ToList();
            var parameters = Request.GetQueryNameValuePairs();
            string controllerName = values["controllername"].ToString();
            string serviceName = values["servicename"].ToString();
            return null;
            if (!values.Keys.Contains("controllername") || !values.Keys.Contains("servicename"))
                return null;
            var client = new RestClient("https://api.twitter.com/1.1");
            var request = new RestRequest();
            request.Method = GetMethod(Request.Method.Method);
            request.AddHeaders((from h in headers select new KeyValuePair<string, string>(h.Key, string.Join(",", h.Value))).ToList());
            foreach (var parameter in parameters)
                request.AddParameter(parameter.Key, parameter.Value);
            IRestResponse response = null;
            switch (request.Method)
            {
                case Method.GET:
                    response = client.Get(request);
                    break;
                case Method.POST:
                    response = client.Post(request);
                    break;
                case Method.PUT:
                    response = client.Put(request);
                    break;
                case Method.DELETE:
                    response = client.Delete(request);
                    break;
                default:
                    break;
            }
            return response;
        }

        private Method GetMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    return Method.GET;
                case "POST":
                    return Method.POST;
                case "PUT":
                    return Method.PUT;
                case "DELETE":
                    return Method.DELETE;
                default:
                    return Method.GET;
            }
        }
    }
}
