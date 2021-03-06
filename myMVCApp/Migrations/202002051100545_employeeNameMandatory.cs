﻿namespace myMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeNameMandatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
