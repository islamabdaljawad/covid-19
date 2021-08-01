namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kuyjkj : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.cities", "itmid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cities", "itmid", c => c.String());
        }
    }
}
