using System.Data.Entity;
using SqlServerPersistence.Assistence;
using SqlServerPersistence.Migrations;

namespace SqlServerPersistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }

        public ModelContext() : base(ClsCache.ConnectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
    }
}
