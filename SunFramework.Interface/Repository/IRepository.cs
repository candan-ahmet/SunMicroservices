using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Repository
{
    public interface IBaseRepository<T, TPrimaryKey> where T : IEntityModel<TPrimaryKey> where TPrimaryKey : new()
    {
        T GetByKey(TPrimaryKey primaryKey);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Insert(T datas);
        IList<T> Insert(IList<T> items);
        T Update(T data);
        T Delete(T data);
        IList<T> Delete(Expression<Func<T, bool>> predicate);
    }
}
