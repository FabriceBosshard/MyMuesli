using System.Data.Entity.Migrations;
using MyMuesli.Service;

namespace MyMuesli.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyCerealContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyCerealContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}