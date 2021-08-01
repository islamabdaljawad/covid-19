namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delll : DbMigration
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
                        ApplicationUser_Id = c.String(),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.hospital_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.avilable_leds", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.avilable_leds", new[] { "ApplicationUser_Id1" });
            DropTable("dbo.avilable_leds");
        }
    }
}
