using AspectCore.DynamicProxy;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Authorization
{
    public class ReadAttribute : AbstractInterceptorAttribute
    {
        string _roles;
        string _users;
        public string Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
        public string Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        public ReadAttribute(string users, string roles)
        {
            Users = users;
            Roles = roles;
        }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            IEnumerable<IRoleModel> userRoles = ((dynamic)context.Implementation).Roles;
            IUserModel user = ((dynamic)context.Implementation).User;
            IEnumerable<IUserIdentityModel> userIdentities = ((dynamic)context.Implementation).UserIdentites;
            bool result = true;

            if (!string.IsNullOrEmpty(Roles))
            {
                string[] roles = Roles.Split(',');
                result = (from ur in userRoles
                          join r in roles on ur.RoleName equals r
                          select ur).Any();
            }

            if (!string.IsNullOrEmpty(Users))
            {
                string[] users = Users.Split(',');
                result = (from ui in userIdentities
                          join u in users on ui.Value equals u
                          select ui).Any();
            }

            if (!result)
                context.ReturnValue = null;
            else
                await next(context);
        }
    }
}
