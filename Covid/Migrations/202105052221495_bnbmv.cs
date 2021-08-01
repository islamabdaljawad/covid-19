namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bnbmv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUsercity", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUsercity", "city_Id", "dbo.cities");
            DropIndex("dbo.ApplicationUsercity", new[] { "Id" });
            DropIndex("dbo.ApplicationUsercity", new[] { "city_Id" });
            CreateTable(
                "dbo.ApplicationUsercities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        city_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.city_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.cities", t => t.city_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.city_Id);
            
            DropTable("dbo.ApplicationUsercity");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUsercity",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        city_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.city_Id });
            
            DropForeignKey("dbo.ApplicationUsercities", "city_Id", "dbo.cities");
            DropForeignKey("dbo.ApplicationUsercities", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUsercities", new[] { "city_Id" });
            DropIndex("dbo.ApplicationUsercities", new[] { "Id" });
            DropTable("dbo.ApplicationUsercities");
            CreateIndex("dbo.ApplicationUsercity", "city_Id");
            CreateIndex("dbo.ApplicationUsercity", "Id");
            AddForeignKey("dbo.ApplicationUsercity", "city_Id", "dbo.cities", "city_Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUsercity", "Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
