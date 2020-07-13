namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedGlucoseTrackerForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GlucoseTracker", "UserId", "dbo.User");
            DropIndex("dbo.GlucoseTracker", new[] { "UserId" });
            RenameColumn(table: "dbo.GlucoseTracker", name: "UserId", newName: "User_UserId");
            AlterColumn("dbo.GlucoseTracker", "User_UserId", c => c.Int());
            CreateIndex("dbo.GlucoseTracker", "User_UserId");
            AddForeignKey("dbo.GlucoseTracker", "User_UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GlucoseTracker", "User_UserId", "dbo.User");
            DropIndex("dbo.GlucoseTracker", new[] { "User_UserId" });
            AlterColumn("dbo.GlucoseTracker", "User_UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.GlucoseTracker", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.GlucoseTracker", "UserId");
            AddForeignKey("dbo.GlucoseTracker", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
