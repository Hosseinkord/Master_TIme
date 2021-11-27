namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumOfClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enters", "NumClass", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enters", "NumClass");
        }
    }
}
