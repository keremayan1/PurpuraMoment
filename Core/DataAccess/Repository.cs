using Core.Entities;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDbContext _context;
        private DbSet<TEntity> _entities;

        public Repository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());
        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await Entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            if (_entities == null) throw new ArgumentNullException(nameof(_entities));
            _entities.RemoveRange(_entities);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.AsNoTracking();
            _entities.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async  Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void BulkInsert(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _entities.AddRange(entities);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetSql(string sql)
        {
            return Entities.FromSqlRaw(sql);
        }
    }
}
