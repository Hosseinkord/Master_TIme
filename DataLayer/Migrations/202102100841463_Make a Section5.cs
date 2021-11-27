namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterLessons",
                c => new
                    {
                        MasterLessonId = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                        Prefer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MasterLessonId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Masters", t => t.MasterId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.LessonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MasterLessons", "MasterId", "dbo.Masters");
            DropForeignKey("dbo.MasterLessons", "LessonId", "dbo.Lessons");
            DropIndex("dbo.MasterLessons", new[] { "LessonId" });
            DropIndex("dbo.MasterLessons", new[] { "MasterId" });
            DropTable("dbo.MasterLessons");
        }
    }
}
