namespace SunFramework.DataAccess.Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceStatus()
        {
            Services = new HashSet<Service>();
        }

        [Key]
        public int ServiceStatusId { get; set; }

        [Required]
        [StringLength(10)]
        public string StatusCode { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }
    }
}
