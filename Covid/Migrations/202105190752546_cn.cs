namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsersymptoms", "datetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsersymptoms", "datetime");
        }
    }
}
