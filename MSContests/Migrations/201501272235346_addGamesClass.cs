namespace MSContests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGamesClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RegisterDate = c.DateTime(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        WpAppName = c.String(nullable: false),
                        WpAppUrl = c.String(nullable: false),
                        W8AppName = c.String(),
                        W8AppUrl = c.String(),
                        XboxAppName = c.String(),
                        XboxAppUrl = c.String(),
                        AppleAppName = c.String(),
                        AppleAppUrl = c.String(),
                        GoogleAppName = c.String(),
                        GoogleAppUrl = c.String(),
                        Comments = c.String(),
                        Competitor_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitors", t => t.Competitor_Id)
                .Index(t => t.Competitor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Competitor_Id", "dbo.Competitors");
            DropIndex("dbo.Games", new[] { "Competitor_Id" });
            DropTable("dbo.Games");
        }
    }
}
