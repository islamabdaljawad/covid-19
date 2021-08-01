namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delllsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.avilable_leds",
                c => new
                    {
                        hospital_Id = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        show = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.hospital_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.avilable_leds", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.avilable_leds", new[] { "UserId" });
            DropTable("dbo.avilable_leds");
        }
    }
}
