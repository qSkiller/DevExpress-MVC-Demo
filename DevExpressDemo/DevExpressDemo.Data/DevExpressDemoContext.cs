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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DevExpressDemoContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shape> Shapes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}