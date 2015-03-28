namespace MSContests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newClasses3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UniversalApps");
            AlterColumn("dbo.UniversalApps", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UniversalApps", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UniversalApps");
            AlterColumn("dbo.UniversalApps", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.UniversalApps", "Id");
        }
    }
}
