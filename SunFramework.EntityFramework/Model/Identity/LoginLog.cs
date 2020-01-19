namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginLog")]
    public partial class LoginLog
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTimeOffset LoginDate { get; set; }
    }
}
