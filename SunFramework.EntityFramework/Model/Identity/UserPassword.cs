//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunFramework.DataAccess.Model.Identity
{
    using SunFramework.Interface.Model;
    using System;
    using System.Collections.Generic;
    
    public partial class UserPassword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserPassword()
        {
            this.UserPassword1 = new HashSet<IUserPasswordModel>();
        }
    
        public int UserPasswordId { get; set; }
        public System.Guid UserId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public Nullable<System.DateTimeOffset> ExpriyDate { get; set; }
        public Nullable<int> ChangeUserPasswordId { get; set; }
    
        public virtual IUserModel User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IUserPasswordModel> UserPassword1 { get; set; }
        public virtual IUserPasswordModel UserPassword2 { get; set; }
    }
}
