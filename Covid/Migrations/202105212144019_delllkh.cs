namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delllkh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.avilable_leds", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.avilable_leds", new[] { "ApplicationUser_Id1" });
            DropTable("dbo.avilable_leds");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.hospital_Id);
            
            CreateIndex("dbo.avilable_leds", "ApplicationUser_Id1");
            AddForeignKey("dbo.avilable_leds", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
    }
}
