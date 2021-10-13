namespace domainmodels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leave2 : DbMigration
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
                        Gender = c.String(),
                        Password = c.String(),
                        Mobile = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EMPID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
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
            DropIndex("dbo.Leaves", new[] { "EMPID" });
            DropIndex("dbo.Employees", new[] { "RoleID" });
            DropTable("dbo.Leaves");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
        }
    }
}
