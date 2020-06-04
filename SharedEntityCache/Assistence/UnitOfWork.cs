using SqlServerPersistence.Model;

namespace SharedEntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext();

        public static void Dispose()
        {
            db?.Dispose();
        }
        public static void Set_Save()
        {
            db.SaveChanges();
        }
    }
}
