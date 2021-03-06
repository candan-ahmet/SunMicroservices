﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Model
{
    public interface IServiceModel : IEntity
    {
        int ServiceId { get; set; }
        int ServiceStatusId { get; set; }
        string HostName { get; set; }
        int PortNo { get; set; }
        Nullable<int> BackupServiceId { get; set; }
        ICollection<IServiceModel> Service1 { get; set; }
        IServiceModel Service2 { get; set; }
        IServiceStatusModel ServiceStatu { get; set; }
        ICollection<IServiceRequestModel> ServiceRequests { get; set; }
        ICollection<IServiceResponseModel> ServiceResponses { get; set; }
    }

    public interface IServiceRequestModel : IEntity
    {
        int ServiceRequestId { get; set; }
        int ServiceId { get; set; }
        DateTime RequestDate { get; set; }
        string RequestIP { get; set; }
        string RequestData { get; set; }
        IServiceModel Service { get; set; }
        ICollection<IServiceResponseModel> ServiceResponses { get; set; }
    }

    public interface IServiceResponseModel : IEntity
    {
        int ServiceResponseId { get; set; }
        int ServiceId { get; set; }
        Nullable<int> ServiceRequestId { get; set; }
        Nullable<System.DateTime> ResponseDate { get; set; }
        string ResponseStatusCode { get; set; }
        string ResponseData { get; set; }
        IServiceModel Service { get; set; }
        IServiceRequestModel ServiceRequest { get; set; }
    }

    public interface IServiceStatusModel : IEntity
    {
        int ServiceStatusId { get; set; }
        string StatusCode { get; set; }
        string StatusName { get; set; }
        ICollection<IServiceModel> Services { get; set; }
    }
}
