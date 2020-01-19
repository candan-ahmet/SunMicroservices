using SunFramework.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Insert(TEntity datas);
        IEnumerable<TEntity> Insert(IEnumerable<TEntity> items);
        TEntity Delete(TEntity data);
        ICollection<TEntity> Delete(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
