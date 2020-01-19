﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Model
{
    public interface IIdentityTypeModel : IEntity
    {
        int IdentityTypeId { get; set; }
        string TypeName { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface ILoginLogModel : IEntity
    {
        Guid UserId { get; set; }
        DateTimeOffset LoginDate { get; set; }
    }

    public interface IRoleModel : IEntity
    {
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleCode { get; set; }
        Nullable<int> ParentRoleId { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface IUserModel : IEntity
    {
        Guid UserId { get; set; }
        bool IsActive { get; set; }
        bool IsLock { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface IUserIdentityModel : IEntity
    {
        Nullable<Guid> UserId { get; set; }
        string Value { get; set; }
        int IdentityTypeId { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface IUserPasswordModel : IEntity
    {
        int UserPasswordId { get; set; }
        Guid UserId { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        bool IsActive { get; set; }
        System.DateTimeOffset CreatedDate { get; set; }
        Nullable<DateTimeOffset> ExpriyDate { get; set; }
        Nullable<int> ChangedUserPasswordId { get; set; }
    }
}
