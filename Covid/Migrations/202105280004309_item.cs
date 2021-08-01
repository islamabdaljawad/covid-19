namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class item : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cities", "itemid", c => c.Int(nullable: false));
            DropColumn("dbo.cities", "itmid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cities", "itmid", c => c.Int(nullable: false));
            DropColumn("dbo.cities", "itemid");
        }
    }
}
