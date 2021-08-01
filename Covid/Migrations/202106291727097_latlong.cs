namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.items", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.items", "Long", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.items", "Long");
            DropColumn("dbo.items", "Lat");
        }
    }
}
