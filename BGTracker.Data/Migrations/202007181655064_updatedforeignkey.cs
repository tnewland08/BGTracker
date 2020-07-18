namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodAndDrink", "UserId", "dbo.User");
            DropForeignKey("dbo.GlucoseTracker", "UserId", "dbo.User");
            DropIndex("dbo.FoodAndDrink", new[] { "UserId" });
            DropIndex("dbo.GlucoseTracker", new[] { "UserId" });
            RenameColumn(table: "dbo.FoodAndDrink", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.GlucoseTracker", name: "UserId", newName: "Id");
            AlterColumn("dbo.FoodAndDrink", "Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.GlucoseTracker", "Id", c => c.String(maxLength: 128));
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
            AlterColumn("dbo.GlucoseTracker", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.FoodAndDrink", "Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.GlucoseTracker", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.FoodAndDrink", name: "Id", newName: "UserId");
            CreateIndex("dbo.GlucoseTracker", "UserId");
            CreateIndex("dbo.FoodAndDrink", "UserId");
            AddForeignKey("dbo.GlucoseTracker", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.FoodAndDrink", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
