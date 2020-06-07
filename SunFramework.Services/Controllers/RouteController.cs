using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SunFramework.Manager;
using SunFramework.Manager.Abstraction;
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
        IUnitOfWork unitOfWork;

        public RouteController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public object Get()
        {
            return getRequest();
        }

        [HttpPost]
        public object Post(JObject data)
        {
            return getRequest();
        }

        [HttpPut]
        public object Put(JObject data)
        {
            return getRequest();
        }

        [HttpDelete]
        public object Delete(string param)
        {
            return getRequest();
        }

        [HttpDelete]
        public object Delete(JObject data)
        {
            return getRequest();
        }

        private object getRequest()
        {
            var activeServices = unitOfWork.ServiceManager.GetActiveServices();
            unitOfWork.ServiceManager.UpdateService(activeServices.First());
            var cacheList = unitOfWork.CacheManager.GetCacheValues("");
            ResponseModel result = new ResponseModel();
            var values = Request.GetRouteData().Values;
            var headers = Request.Headers.ToList();
            var parameters = Request.GetQueryNameValuePairs();
            string controllerName = values["controllername"].ToString();
            string serviceName = values["servicename"].ToString();
            if (!values.Keys.Contains("controllername") || !values.Keys.Contains("servicename"))
                return null;
            var service = activeServices.SingleOrDefault(c => c.ServiceName == serviceName);
            var client = new RestClient($"http://{service.Host}:{service.PortNo}/api/{controllerName}");
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
            return JsonConvert.DeserializeObject(response.Content);
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
