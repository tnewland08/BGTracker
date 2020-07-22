namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodAndDrink", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.GlucoseTracker", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.FoodAndDrink", new[] { "Id" });
            DropIndex("dbo.GlucoseTracker", new[] { "Id" });
            DropColumn("dbo.FoodAndDrink", "Id");
            DropColumn("dbo.ApplicationUser", "OwnerId");
            DropColumn("dbo.GlucoseTracker", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GlucoseTracker", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ApplicationUser", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.FoodAndDrink", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.GlucoseTracker", "Id");
            CreateIndex("dbo.FoodAndDrink", "Id");
            AddForeignKey("dbo.GlucoseTracker", "Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.FoodAndDrink", "Id", "dbo.ApplicationUser", "Id");
        }
    }
}
