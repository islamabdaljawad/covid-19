namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itmid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cities", "itmid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cities", "itmid", c => c.String());
        }
    }
}
