using System.Data.Entity.Migrations;

namespace DevExpressDemo.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DevExpressDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DevExpressDemoContext context)
        {
        }
    }
}