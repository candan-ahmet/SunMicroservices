namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserIdentity")]
    public partial class UserIdentity
    {
        public Guid? UserId { get; set; }

        [Key]
        [StringLength(50)]
        public string Value { get; set; }

        public int IdentityTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public virtual IdentityType IdentityType { get; set; }

        public virtual User User { get; set; }
    }
}
