using System.Data.Entity;
using MySql.Data.Entity;
using OrmVsAdoNetComparison.Data.Entity;

namespace OrmVsAdoNetComparison.Data
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComparisonContext : DbContext
    {
        public ComparisonContext() : base()
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComparisonContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
