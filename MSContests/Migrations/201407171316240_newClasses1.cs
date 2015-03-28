namespace MSContests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newClasses1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Position = c.String(),
                        AreYouAStudent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MultiPlatformApps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RegisterDate = c.DateTime(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        W8AppName = c.String(nullable: false),
                        W8AppUrl = c.String(),
                        WpAppName = c.String(nullable: false),
                        WpAppUrl = c.String(),
                        AppleAppName = c.String(nullable: false),
                        AppleAppUrl = c.String(),
                        GoogleAppName = c.String(nullable: false),
                        GoogleAppUrl = c.String(),
                        Comments = c.String(),
                        Competitor_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitors", t => t.Competitor_Id)
                .Index(t => t.Competitor_Id);
            
            CreateTable(
                "dbo.UniversalApps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RegisterDate = c.DateTime(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        W8AppName = c.String(nullable: false),
                        W8AppUrl = c.String(),
                        WpAppName = c.String(nullable: false),
                        WpAppUrl = c.String(),
                        Comments = c.String(),
                        Competitor_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitors", t => t.Competitor_Id)
                .Index(t => t.Competitor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UniversalApps", "Competitor_Id", "dbo.Competitors");
            DropForeignKey("dbo.MultiPlatformApps", "Competitor_Id", "dbo.Competitors");
            DropIndex("dbo.UniversalApps", new[] { "Competitor_Id" });
            DropIndex("dbo.MultiPlatformApps", new[] { "Competitor_Id" });
            DropTable("dbo.UniversalApps");
            DropTable("dbo.MultiPlatformApps");
            DropTable("dbo.Competitors");
        }
    }
}
