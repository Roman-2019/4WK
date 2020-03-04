namespace Homework12_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Homework12_DAL.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Homework12_DAL.MyDBContext";
        }

        protected override void Seed(Homework12_DAL.MyDBContext context)
        {
            //context.DetailTypes.Add(new Models.DetailType { Name = "Wheel" });
            //context.DetailTypes.Add(new Models.DetailType { Name = "Door" });
            //context.DetailTypes.Add(new Models.DetailType { Name = "Engine" });
            //context.DetailTypes.Add(new Models.DetailType { Name = "SteeringWheel" });
        }
    }
}
