namespace Employeleave.Domainmodels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leaves : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EMPID = c.Int(nullable: false, identity: true),
                        EMPname = c.String(),
                        Email = c.String(),
                        PMID = c.Int(nullable: false),
                        Gender = c.String(),
                        PasswordHash = c.String(),
                        Mobile = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        IsHR = c.Boolean(nullable: false),
                        IsManager = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EMPID)
                .ForeignKey("dbo.Projectmanagers", t => t.PMID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.PMID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Projectmanagers",
                c => new
                    {
                        PMID = c.Int(nullable: false, identity: true),
                        Projectame = c.String(),
                    })
                .PrimaryKey(t => t.PMID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Rolename = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveID = c.Int(nullable: false, identity: true),
                        EMPID = c.Int(nullable: false),
                        Status = c.String(),
                        Fromdate = c.DateTime(nullable: false),
                        Todate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.LeaveID)
                .ForeignKey("dbo.Employees", t => t.EMPID, cascadeDelete: true)
                .Index(t => t.EMPID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "EMPID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Employees", "PMID", "dbo.Projectmanagers");
            DropIndex("dbo.Leaves", new[] { "EMPID" });
            DropIndex("dbo.Employees", new[] { "RoleID" });
            DropIndex("dbo.Employees", new[] { "PMID" });
            DropTable("dbo.Leaves");
            DropTable("dbo.Roles");
            DropTable("dbo.Projectmanagers");
            DropTable("dbo.Employees");
        }
    }
}
