using System.Data.Entity;
using MySql.Data.Entity;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using log4net;

namespace OrmVsAdoNetComparison.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComparisonContext : DbContext
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ComparisonContext() : base("ComparisonContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComparisonContext, Configuration>());
            //Database.Log = s => Log.Debug(s);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Image>();

        }
    }
}
