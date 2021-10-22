namespace Employeleave.Domainmodels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    


    internal sealed class Configuration : DbMigrationsConfiguration< Employeleave.Domainmodels.context.Employeeleavecontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Employeleave.Domainmodels.context.Employeeleavecontext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
