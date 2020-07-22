namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodAndDrink", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.GlucoseTracker", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FoodAndDrink", "Id");
            CreateIndex("dbo.GlucoseTracker", "Id");
            AddForeignKey("dbo.FoodAndDrink", "Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.GlucoseTracker", "Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GlucoseTracker", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.FoodAndDrink", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.GlucoseTracker", new[] { "Id" });
            DropIndex("dbo.FoodAndDrink", new[] { "Id" });
            DropColumn("dbo.GlucoseTracker", "Id");
            DropColumn("dbo.FoodAndDrink", "Id");
        }
    }
}
