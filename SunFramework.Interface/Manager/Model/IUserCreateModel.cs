using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Manager.Model
{
    public interface IUserCreateModel
    {
        string UserName { get; set; }
        int IdentityTypeId { get; set; }
        string Password { get; set; }
    }
}
