namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kuyt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cities", "itmid", c => c.String());
            AlterColumn("dbo.cities", "city_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.cities", "city_Id");
            AddForeignKey("dbo.cities", "city_Id", "dbo.items", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cities", "city_Id", "dbo.items");
            DropIndex("dbo.cities", new[] { "city_Id" });
            AlterColumn("dbo.cities", "city_Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.cities", "itmid");
        }
    }
}
