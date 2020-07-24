namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodidtoitemid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FoodAndDrink");
            DropColumn("dbo.FoodAndDrink", "FoodId");
            AddColumn("dbo.FoodAndDrink", "ItemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FoodAndDrink", "ItemId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FoodAndDrink");
            DropColumn("dbo.FoodAndDrink", "ItemId");
            AddColumn("dbo.FoodAndDrink", "FoodId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FoodAndDrink", "FoodId");
        }
    }
}
