using BapKids.DataAccess.Interfaces;
using BapKids.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BapKids.DataAccess.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BapKidsContext _context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(BapKidsContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        //get by Id
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        //Find
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        //add
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
            //_context.Entry(entity).State = EntityState.Added;
        }

        //update
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        //delete
        public virtual void Delete(object id)
        {
            TEntity entity = GetById(id);
            dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
