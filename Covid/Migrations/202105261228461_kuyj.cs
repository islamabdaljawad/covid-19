namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kuyj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cities", "itm_item_id", "dbo.items");
            DropIndex("dbo.cities", new[] { "itm_item_id" });
            AddColumn("dbo.items", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.items", "state", c => c.String());
            DropPrimaryKey("dbo.items");
            AddPrimaryKey("dbo.items", "id");
            DropColumn("dbo.cities", "itm_item_id");
            DropColumn("dbo.items", "item_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.items", "item_id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.cities", "itm_item_id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.items");
            AddPrimaryKey("dbo.items", "item_id");
            DropColumn("dbo.items", "state");
            DropColumn("dbo.items", "id");
            CreateIndex("dbo.cities", "itm_item_id");
            AddForeignKey("dbo.cities", "itm_item_id", "dbo.items", "item_id");
        }
    }
}
