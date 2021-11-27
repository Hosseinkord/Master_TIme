namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterDates", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.MasterDates", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MasterDates", "MyProperty", c => c.Boolean(nullable: false));
            DropColumn("dbo.MasterDates", "Status");
        }
    }
}
