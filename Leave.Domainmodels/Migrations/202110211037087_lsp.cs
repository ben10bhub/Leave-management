﻿namespace Employeleave.Domainmodels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lsp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsSpecialPermission", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsSpecialPermission");
        }
    }
}
