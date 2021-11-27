namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Help2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Help2", "DateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Help2", "DateId");
        }
    }
}
