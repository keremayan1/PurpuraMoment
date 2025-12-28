using Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SQLContext:DbContext,IDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=192.168.1.104,1433;Initial Catalog=PurpuraPhoto;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=C.ilme.124;Trust Server Certificate=True");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PurpuraMoment;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
