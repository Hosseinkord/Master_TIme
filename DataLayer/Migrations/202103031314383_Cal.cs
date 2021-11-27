namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cal_End", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cal_End", "Count");
        }
    }
}
