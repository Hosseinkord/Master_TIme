namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Enters", "startTime");
            DropColumn("dbo.Enters", "EndTime");
            DropColumn("dbo.Enters", "NumClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enters", "NumClass", c => c.Int(nullable: false));
            AddColumn("dbo.Enters", "EndTime", c => c.Int(nullable: false));
            AddColumn("dbo.Enters", "startTime", c => c.Int(nullable: false));
        }
    }
}
