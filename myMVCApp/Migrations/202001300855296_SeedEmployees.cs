namespace myMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedEmployees : DbMigration
    {
        public override void Up()
        {
            // Error:Cannot insert explicit value for identity column in table 'Employees' when IDENTITY_INSERT is set to OFF.
            // When the IDENTITY_INSERT is set OFF. The PRIMARY KEY "ID" MUST NOT BE PRESENT
            Sql(@"INSERT INTO [dbo].[Employees] ([Name], [Gender], [City]) VALUES (N'John', N'Male', N'NY')
                  INSERT INTO [dbo].[Employees] ([Name], [Gender], [City]) VALUES (N'Dusan', N'Male',N'LM')      
                ");
        }
        
        public override void Down()
        {
        }
    }
}
