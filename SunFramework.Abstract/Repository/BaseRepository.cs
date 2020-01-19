using SunFramework.Interface.Model;
using SunFramework.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SunFramework.Abstract.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private DbContext _dbContext;
        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }

        public TEntity Delete(TEntity data)
        {
            return _dbContext.Set<TEntity>().Remove(data);
        }

        public ICollection<TEntity> Delete(Expression<Func<TEntity, bool>> predicate)
        {
            ICollection<TEntity> deleteList = new List<TEntity>();
            foreach (var item in _dbContext.Set<TEntity>().Where(predicate))
                deleteList.Add(_dbContext.Set<TEntity>().Remove(item));
            return deleteList;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().Where(c => true);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().First(predicate);
        }

        public TEntity Insert(TEntity data)
        {
            return _dbContext.Set<TEntity>().Add(data);
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> items)
        {
            return _dbContext.Set<TEntity>().AddRange(items);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
