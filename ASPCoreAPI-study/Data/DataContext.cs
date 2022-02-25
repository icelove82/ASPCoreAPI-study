using Microsoft.EntityFrameworkCore;

namespace ASPCoreAPI_study.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeros { get; set; }
    }
}
