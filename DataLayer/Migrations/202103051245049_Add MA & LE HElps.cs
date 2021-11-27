namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMALEHElps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LEHes",
                c => new
                    {
                        LeHeId = c.Int(nullable: false, identity: true),
                        LessonCode = c.Int(nullable: false),
                        LessonGroup = c.Int(nullable: false),
                        LUnit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeHeId);
            
            CreateTable(
                "dbo.MAHes",
                c => new
                    {
                        MAHeId = c.Int(nullable: false, identity: true),
                        MasterCode = c.Int(nullable: false),
                        NumLesson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MAHeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MAHes");
            DropTable("dbo.LEHes");
        }
    }
}
