namespace myMVCApp.Migrations
{
    using myMVCApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<myMVCApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(myMVCApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //### 1.) Create a new empty migration add-migration SeedEmployees
            //    2.) public partial class SeedEmployees : DbMigration do public override void Up()
            //        Sql(@"INSERT INTO [dbo].[Employees] ([Name], [Gender], [City] VALUES (N'John', N'Male' N'NY')");
           
            /*context.Employees.AddOrUpdate(x => x.EmployeeId,
                new Employee() { EmployeeId = 1, Name = "John", City = "NY", Gender = "Male" },
                new Employee() { EmployeeId = 2, Name = "Dusan", City = "LM", Gender = "Male" }
            );*/
        }
    }
}
