namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedguidtoapplicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "OwnerId");
        }
    }
}
