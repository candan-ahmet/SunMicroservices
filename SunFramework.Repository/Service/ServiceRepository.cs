using SunFramework.Interface.Repository;
using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunFramework.Abstract.Repository;
using System.Data.Entity;
using SunFramework.DataAccess.Model.Service;

namespace SunFramework.Repository.Identity
{
    public class ServiceRepository : BaseRepository<IServiceModel>, IServiceRepository
    {
        public ServiceRepository() : base(new ModelService())
        {

        }

        public IQueryable<IServiceModel> GetActiveServices()
        {
            return from s in Db.Set<Service>()
                   join ss in Db.Set<ServiceStatus>() on s.ServiceStatusId equals ss.ServiceStatusId
                   where ss.StatusCode == "A"
                   select s;
        }

        public IServiceModel Update(int serviceId, IServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
