namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nbvh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cities", "Isselected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.cities", "Isselected");
        }
    }
}
