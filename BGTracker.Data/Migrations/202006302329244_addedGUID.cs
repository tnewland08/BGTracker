namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGUID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "OwnerId");
        }
    }
}
