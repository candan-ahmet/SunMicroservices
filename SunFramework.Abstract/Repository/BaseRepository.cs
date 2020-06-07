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
        public DbContext Db { get; set; }

        public BaseRepository(string nameOrConnectionString)
        {
            Db = new DbContext(nameOrConnectionString);
        }

        public BaseRepository(DbContext dbContext)
        {
            Db = dbContext;
        }

        public TEntity Delete(TEntity data)
        {
            return Db.Set<TEntity>().Remove(data);
        }

        public ICollection<TEntity> Delete(Expression<Func<TEntity, bool>> predicate)
        {
            ICollection<TEntity> deleteList = new List<TEntity>();
            foreach (var item in Db.Set<TEntity>().Where(predicate))
                deleteList.Add(Db.Set<TEntity>().Remove(item));
            return deleteList;
        }

        public IQueryable<TEntity> Get()
        {
            return Db.Set<TEntity>().Where(c => true);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().First(predicate);
        }

        public TEntity Insert(TEntity data)
        {
            return Db.Set<TEntity>().Add(data);
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> items)
        {
            return Db.Set<TEntity>().AddRange(items);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Db.SaveChangesAsync();
        }
    }
}
