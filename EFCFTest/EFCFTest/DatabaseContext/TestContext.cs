using EFCFTest.Model;
using System.Data.Entity;

namespace EFCFTest.DatabaseContext
{
    public class TestContext : DbContext
    {
        public TestContext(): base("name=TestConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

        // fluent
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("test");
        }
    }
}
