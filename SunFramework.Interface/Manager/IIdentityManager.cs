using SunFramework.Interface.Manager.Model;
using SunFramework.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Manager
{
    public interface IIdentityManager : IManager
    {
        IUserCreateModel CreateUser(IUserCreateModel user);
    }
}
