using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        IQueryable<T> GetSql(string sql);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task BulkInsertAsync(IEnumerable<T> entities);
        void BulkInsert(IEnumerable<T> entities);
    }

}
