namespace MSContests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newClasses2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MultiPlatformApps");
            AlterColumn("dbo.MultiPlatformApps", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.MultiPlatformApps", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MultiPlatformApps");
            AlterColumn("dbo.MultiPlatformApps", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.MultiPlatformApps", "Id");
        }
    }
}
