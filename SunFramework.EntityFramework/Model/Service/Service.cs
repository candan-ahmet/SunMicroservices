namespace SunFramework.DataAccess.Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            BackedServices = new HashSet<Service>();
            ServiceRequests = new HashSet<ServiceRequest>();
            ServiceResponses = new HashSet<ServiceResponse>();
        }

        public int ServiceId { get; set; }

        public int ServiceStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string HostName { get; set; }

        public int PortNo { get; set; }

        public int? BackupServiceId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> BackedServices { get; set; }

        public virtual Service BackupService { get; set; }

        public virtual ServiceStatus ServiceStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }
    }
}
