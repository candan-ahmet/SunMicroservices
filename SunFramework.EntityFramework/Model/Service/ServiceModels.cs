using SunFramework.Abstract.Entity;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.DataAccess.Model.Service
{
    public partial class Service : BaseEntity, IServiceModel
    {

    }

    public partial class ServiceRequest : BaseEntity, IServiceRequestModel
    {

    }

    public partial class ServiceResponse : BaseEntity, IServiceResponseModel
    {

    }

    public partial class ServiceStatu : BaseEntity, IServiceStatusModel
    {

    }
}
