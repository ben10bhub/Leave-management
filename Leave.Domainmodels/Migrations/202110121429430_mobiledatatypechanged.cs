namespace Employeleave.Domainmodels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobiledatatypechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Mobile", c => c.Int(nullable: false));
        }
    }
}
