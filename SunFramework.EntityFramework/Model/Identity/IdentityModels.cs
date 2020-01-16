using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.EntityFramework.Model.Identity
{
    //Test
    public partial class IdentityType : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return IdentityTypeId;
        } 
    }

    public partial class UserIdentity : IEntityModel<string>
    {
        public string GetPrimaryKey()
        {
            return Value;
        }
    }

    public partial class User : IEntityModel<Guid>
    {
        public Guid GetPrimaryKey()
        {
            return UserId;
        }
    }

    public partial class UserPassword : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return UserPasswordId;
        }
    }

    public partial class Role : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return RoleId;
        }
    }

    public partial class LoginLog : IEntityModel<Guid, DateTimeOffset>
    {
        public Guid GetPrimaryKey1()
        {
            return UserId;
        }

        public DateTimeOffset GetPrimaryKey2()
        {
            return LoginDate;
        }
    }
}
