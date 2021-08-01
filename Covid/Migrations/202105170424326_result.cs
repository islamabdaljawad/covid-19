namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class result : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.results",
                c => new
                    {
                        result_id = c.Int(nullable: false, identity: true),
                        corona = c.Int(nullable: false),
                        commoncold = c.Int(nullable: false),
                        flu = c.Int(nullable: false),
                        Allergies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.result_id);
            
            AddColumn("dbo.ApplicationUsersymptoms", "result_id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ApplicationUsersymptoms");
            AddPrimaryKey("dbo.ApplicationUsersymptoms", new[] { "Id", "symptom_Id", "result_id" });
            CreateIndex("dbo.ApplicationUsersymptoms", "result_id");
            AddForeignKey("dbo.ApplicationUsersymptoms", "result_id", "dbo.results", "result_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsersymptoms", "result_id", "dbo.results");
            DropIndex("dbo.ApplicationUsersymptoms", new[] { "result_id" });
            DropPrimaryKey("dbo.ApplicationUsersymptoms");
            AddPrimaryKey("dbo.ApplicationUsersymptoms", new[] { "Id", "symptom_Id" });
            DropColumn("dbo.ApplicationUsersymptoms", "result_id");
            DropTable("dbo.results");
        }
    }
}
