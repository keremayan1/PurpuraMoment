using Core.DataAccess;
using DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistiration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped(typeof(IDbContext), typeof(SQLContext));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }

    }
}
