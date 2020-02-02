using System.Data.Entity;

namespace DataToExcelLoader
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<Railway> Railways { get; set; }

        public DbSet<Station> Stations { get; set; }
    }
}
