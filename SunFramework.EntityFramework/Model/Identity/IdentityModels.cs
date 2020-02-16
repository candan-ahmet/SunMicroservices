using SunFramework.Abstract.Entity;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.DataAccess.Model.Identity
{
    public partial class IdentityType : BaseEntity, IIdentityTypeModel
    {

    }

    public partial class UserIdentity : BaseEntity, IUserIdentityModel
    {

    }

    public partial class User : BaseEntity, IUserModel
    {

    }

    public partial class UserPassword : BaseEntity, IUserPasswordModel
    {

    }

    public partial class Role : BaseEntity, IRoleModel
    {

    }

    public partial class LoginLog : BaseEntity, ILoginLogModel
    {

    }
}
