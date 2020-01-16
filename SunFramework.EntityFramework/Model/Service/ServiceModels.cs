using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.EntityFramework.Model.Service
{
    public partial class Service : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return ServiceId;
        }
    }

    public partial class ServiceRequest : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return ServiceRequestId;
        }
    }

    public partial class ServiceResponse : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return ServiceResponseId;
        }
    }

    public partial class ServiceStatu : IEntityModel
    {
        public int GetPrimaryKey()
        {
            return ServiceStatusId;
        }
    }
}
