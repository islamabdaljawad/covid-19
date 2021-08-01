namespace Covid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class advice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.advices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.advices");
        }
    }
}
