namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGlucoseTracker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlucoseTracker",
                c => new
                    {
                        TrackerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BloodGlucose = c.Int(nullable: false),
                        CorrectionDose = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCarbs = c.Int(nullable: false),
                        FoodDose = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsulinDose = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeOfDose = c.Time(nullable: false, precision: 7),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TrackerId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GlucoseTracker", "UserId", "dbo.User");
            DropIndex("dbo.GlucoseTracker", new[] { "UserId" });
            DropTable("dbo.GlucoseTracker");
        }
    }
}
