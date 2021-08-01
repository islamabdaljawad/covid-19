namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUsersymptoms", "city_city_Id", "dbo.cities");
            DropIndex("dbo.ApplicationUsersymptoms", new[] { "city_city_Id" });
            CreateIndex("dbo.ApplicationUsercities", "city_Id");
            AddForeignKey("dbo.ApplicationUsercities", "city_Id", "dbo.cities", "city_Id", cascadeDelete: true);
            DropColumn("dbo.ApplicationUsersymptoms", "city_city_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsersymptoms", "city_city_Id", c => c.Int());
            DropForeignKey("dbo.ApplicationUsercities", "city_Id", "dbo.cities");
            DropIndex("dbo.ApplicationUsercities", new[] { "city_Id" });
            CreateIndex("dbo.ApplicationUsersymptoms", "city_city_Id");
            AddForeignKey("dbo.ApplicationUsersymptoms", "city_city_Id", "dbo.cities", "city_Id");
        }
    }
}
