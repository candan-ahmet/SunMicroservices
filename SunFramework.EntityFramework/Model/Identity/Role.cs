namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            ChildRoles = new HashSet<Role>();
            Users = new HashSet<User>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(10)]
        public string RoleCode { get; set; }

        public int? ParentRoleId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> ChildRoles { get; set; }

        public virtual Role ParentRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
