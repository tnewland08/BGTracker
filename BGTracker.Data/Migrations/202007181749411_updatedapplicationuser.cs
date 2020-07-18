namespace BGTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedapplicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ApplicationUser", "Diagnosed", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "TypeOne", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "TypeTwo", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.ApplicationUser", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Diagnosed = c.Int(nullable: false),
                        TypeOne = c.Boolean(nullable: false),
                        TypeTwo = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropColumn("dbo.ApplicationUser", "ModifiedUtc");
            DropColumn("dbo.ApplicationUser", "CreatedUtc");
            DropColumn("dbo.ApplicationUser", "TypeTwo");
            DropColumn("dbo.ApplicationUser", "TypeOne");
            DropColumn("dbo.ApplicationUser", "Diagnosed");
            DropColumn("dbo.ApplicationUser", "BirthDate");
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
        }
    }
}
