namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPassword")]
    public partial class UserPassword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserPassword()
        {
            NextUserPasswords = new HashSet<UserPassword>();
        }

        public int UserPasswordId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordSalt { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ExpriyDate { get; set; }

        public int? ChangedUserPasswordId { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPassword> NextUserPasswords { get; set; }

        public virtual UserPassword ChangedUserPassword { get; set; }
    }
}
