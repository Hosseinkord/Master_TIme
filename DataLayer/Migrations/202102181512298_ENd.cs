namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ENd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helps", "ST", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Helps", "ST");
        }
    }
}
