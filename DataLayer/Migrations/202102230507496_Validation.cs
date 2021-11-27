namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dates", "DateName", c => c.String(nullable: false));
            AlterColumn("dbo.Masters", "MasterName", c => c.String(nullable: false));
            AlterColumn("dbo.Lessons", "LessonName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lessons", "LessonName", c => c.String());
            AlterColumn("dbo.Masters", "MasterName", c => c.String());
            AlterColumn("dbo.Dates", "DateName", c => c.String());
        }
    }
}
