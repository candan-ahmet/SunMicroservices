using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Repository
{
    public interface IServiceRepository : IRepository<IServiceModel>
    {
        IServiceModel Update(int serviceId, IServiceModel model);
        IQueryable<IServiceModel> GetActiveServices();
    }
}
