﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IdentityEntities : DbContext
    {
        public IdentityEntities()
            : base("name=IdentityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserIdentity> UserIdentities { get; set; }
        public virtual DbSet<UserPassword> UserPasswords { get; set; }
    
        public virtual ObjectResult<sp_AddNewUser_Result> sp_AddNewUser(string userName, string passwordHash, string passwordSalt, Nullable<int> identityTypeId)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("PasswordHash", passwordHash) :
                new ObjectParameter("PasswordHash", typeof(string));
    
            var passwordSaltParameter = passwordSalt != null ?
                new ObjectParameter("PasswordSalt", passwordSalt) :
                new ObjectParameter("PasswordSalt", typeof(string));
    
            var identityTypeIdParameter = identityTypeId.HasValue ?
                new ObjectParameter("IdentityTypeId", identityTypeId) :
                new ObjectParameter("IdentityTypeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AddNewUser_Result>("sp_AddNewUser", userNameParameter, passwordHashParameter, passwordSaltParameter, identityTypeIdParameter);
        }
    
        public virtual int sp_AddUser(string userName, string passwordHash, string passwordSalt, Nullable<int> identityTypeId)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("PasswordHash", passwordHash) :
                new ObjectParameter("PasswordHash", typeof(string));
    
            var passwordSaltParameter = passwordSalt != null ?
                new ObjectParameter("PasswordSalt", passwordSalt) :
                new ObjectParameter("PasswordSalt", typeof(string));
    
            var identityTypeIdParameter = identityTypeId.HasValue ?
                new ObjectParameter("IdentityTypeId", identityTypeId) :
                new ObjectParameter("IdentityTypeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddUser", userNameParameter, passwordHashParameter, passwordSaltParameter, identityTypeIdParameter);
        }
    
        public virtual ObjectResult<sp_AddUserPassword_Result> sp_AddUserPassword(string userName, string newUserName, Nullable<int> newIdentityTypeId)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var newUserNameParameter = newUserName != null ?
                new ObjectParameter("NewUserName", newUserName) :
                new ObjectParameter("NewUserName", typeof(string));
    
            var newIdentityTypeIdParameter = newIdentityTypeId.HasValue ?
                new ObjectParameter("NewIdentityTypeId", newIdentityTypeId) :
                new ObjectParameter("NewIdentityTypeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AddUserPassword_Result>("sp_AddUserPassword", userNameParameter, newUserNameParameter, newIdentityTypeIdParameter);
        }
    
        public virtual ObjectResult<sp_UserPassword_Result> sp_UserPassword(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_UserPassword_Result>("sp_UserPassword", userNameParameter);
        }
    }
}
