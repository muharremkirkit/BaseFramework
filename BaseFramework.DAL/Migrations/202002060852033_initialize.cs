namespace BaseFramework.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineName = c.String(),
                        LoggedDate = c.DateTime(),
                        LogLevel = c.Int(),
                        Message = c.String(),
                        Logger = c.String(),
                        Callsite = c.String(),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        IsActive = c.Boolean(),
                        PageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubPageId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        Icon = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Mail = c.String(),
                        Sex = c.Boolean(),
                        Location = c.String(),
                        Browser = c.String(),
                        IP = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePageEvents",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        PageEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.PageEvent_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.PageEvents", t => t.PageEvent_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.PageEvent_Id);
            
            CreateTable(
                "dbo.RolePages",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Page_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Page_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageEvents", "PageId", "dbo.Pages");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RolePages", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.RolePages", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RolePageEvents", "PageEvent_Id", "dbo.PageEvents");
            DropForeignKey("dbo.RolePageEvents", "Role_Id", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.RolePages", new[] { "Page_Id" });
            DropIndex("dbo.RolePages", new[] { "Role_Id" });
            DropIndex("dbo.RolePageEvents", new[] { "PageEvent_Id" });
            DropIndex("dbo.RolePageEvents", new[] { "Role_Id" });
            DropIndex("dbo.PageEvents", new[] { "PageId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.RolePages");
            DropTable("dbo.RolePageEvents");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Pages");
            DropTable("dbo.PageEvents");
            DropTable("dbo.Logs");
        }
    }
}
