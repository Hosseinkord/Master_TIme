namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lessons", "Term", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "Term", c => c.Boolean(nullable: false));
        }
    }
}
