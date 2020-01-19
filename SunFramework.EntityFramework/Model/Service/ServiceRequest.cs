namespace SunFramework.DataAccess.Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceRequest")]
    public partial class ServiceRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceRequest()
        {
            ServiceResponses = new HashSet<ServiceResponse>();
        }

        public int ServiceRequestId { get; set; }

        public int ServiceId { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestIP { get; set; }

        public string RequestData { get; set; }

        public virtual Service Service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }
    }
}
