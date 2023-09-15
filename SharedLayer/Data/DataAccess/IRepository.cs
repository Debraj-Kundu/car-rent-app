using SharedLayer.Core.ValueObjects;
using SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Data.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count { get; }
        IQueryable<TEntity> All();
        TEntity GetById(object id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);
        bool Contains(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Task<OperationResult<IEnumerable<TEntity>>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Delete(Expression<Func<TEntity, bool>> predicate);

    }
}
