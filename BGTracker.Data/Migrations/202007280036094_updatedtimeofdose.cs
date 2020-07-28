namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtimeofdose : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GlucoseTracker", "TimeOfDose", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GlucoseTracker", "TimeOfDose", c => c.Time(nullable: false, precision: 7));
        }
    }
}
