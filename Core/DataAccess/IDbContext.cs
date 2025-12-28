using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

}
