namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodAndDrink",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Item = c.String(nullable: false),
                        IsFood = c.Boolean(nullable: false),
                        IsDrink = c.Boolean(nullable: false),
                        CarbsPerServing = c.Int(nullable: false),
                        ServingSize = c.String(nullable: false),
                        FastActingCarb = c.Boolean(nullable: false),
                        Favorite = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodAndDrink");
        }
    }
}
