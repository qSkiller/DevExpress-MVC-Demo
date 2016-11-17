using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DevExpressDemo.Data.Migrations;
using DevExpressDemo.Data.Models;

namespace DevExpressDemo.Data
{
    public class DevExpressDemoContext : DbContext
    {
        public DevExpressDemoContext() : base("name=DevExpressDemoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DevExpressDemoContext,Configuration>());
        }

        public DbSet<User> Users { set; get; }
        public DbSet<Employee> Employees { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}