namespace SunFramework.DataAccess.Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceResponse")]
    public partial class ServiceResponse
    {
        public int ServiceResponseId { get; set; }

        public int ServiceId { get; set; }

        public int? ServiceRequestId { get; set; }

        public DateTime? ResponseDate { get; set; }

        [StringLength(10)]
        public string ResponseStatusCode { get; set; }

        public string ResponseData { get; set; }

        public virtual Service Service { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
