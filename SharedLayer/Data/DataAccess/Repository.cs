using SharedLayer.Core.ValueObjects;
using SharedLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Data.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainBase, IDomain
    {

        protected DbContext dbContext;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public virtual int Count
        {
            get { return dbContext.Set<TEntity>().Count(); }
        }
        public virtual IQueryable<TEntity> All()
        {
            return dbContext.Set<TEntity>();
        }
        public virtual TEntity GetById(object id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query).AsQueryable() : query.AsQueryable();
        }
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? dbContext.Set<TEntity>().Where(filter).AsQueryable()
                : dbContext.Set<TEntity>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Any(predicate);
        }
        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        public virtual void Delete(int id)
        {
            var entityToDelete = GetById(id);
            Delete(entityToDelete);
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                dbContext.Set<TEntity>().Remove(entity);
            }
        }
        //public virtual async Task<OperationResult<IEnumerable<TEntity>>> GetAllAsync()
        //{
        //    var result = await dbContext.Set<TEntity>().ToListAsync();
        //    Message message = new Message(string.Empty, "Return Successfully");
        //    return new OperationResult<IEnumerable<TEntity>>(result, true, message);
        //}

        public virtual async Task UpdateAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
