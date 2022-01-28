using Microsoft.EntityFrameworkCore;
using MinimalApiSqlSever.Models;

namespace MinimalApiSqlSever.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) => Database.EnsureCreated();
        
        public DbSet<Cliente> Cliente { get; set; }
        
    }
}
