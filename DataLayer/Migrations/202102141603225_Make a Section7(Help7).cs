namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection7Help7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MasterLessons", "MasterId", "dbo.Masters");
            DropForeignKey("dbo.MasterLessons", "LessonId", "dbo.Lessons");
            DropIndex("dbo.MasterLessons", new[] { "MasterId" });
            DropIndex("dbo.MasterLessons", new[] { "LessonId" });
            RenameColumn(table: "dbo.MasterLessons", name: "MasterId", newName: "Master_MasterId");
            RenameColumn(table: "dbo.MasterLessons", name: "LessonId", newName: "Lesson_LessonId");
            CreateTable(
                "dbo.Help2",
                c => new
                    {
                        Help2Id = c.Int(nullable: false, identity: true),
                        MasterCode = c.Int(nullable: false),
                        LessonCode = c.Int(nullable: false),
                        ScHelp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Help2Id);
            
            AddColumn("dbo.MasterLessons", "MasterCode", c => c.Int(nullable: false));
            AddColumn("dbo.MasterLessons", "LessonCode", c => c.Int(nullable: false));
            AlterColumn("dbo.MasterLessons", "Master_MasterId", c => c.Int());
            AlterColumn("dbo.MasterLessons", "Lesson_LessonId", c => c.Int());
            CreateIndex("dbo.MasterLessons", "Lesson_LessonId");
            CreateIndex("dbo.MasterLessons", "Master_MasterId");
            AddForeignKey("dbo.MasterLessons", "Master_MasterId", "dbo.Masters", "MasterId");
            AddForeignKey("dbo.MasterLessons", "Lesson_LessonId", "dbo.Lessons", "LessonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MasterLessons", "Lesson_LessonId", "dbo.Lessons");
            DropForeignKey("dbo.MasterLessons", "Master_MasterId", "dbo.Masters");
            DropIndex("dbo.MasterLessons", new[] { "Master_MasterId" });
            DropIndex("dbo.MasterLessons", new[] { "Lesson_LessonId" });
            AlterColumn("dbo.MasterLessons", "Lesson_LessonId", c => c.Int(nullable: false));
            AlterColumn("dbo.MasterLessons", "Master_MasterId", c => c.Int(nullable: false));
            DropColumn("dbo.MasterLessons", "LessonCode");
            DropColumn("dbo.MasterLessons", "MasterCode");
            DropTable("dbo.Help2");
            RenameColumn(table: "dbo.MasterLessons", name: "Lesson_LessonId", newName: "LessonId");
            RenameColumn(table: "dbo.MasterLessons", name: "Master_MasterId", newName: "MasterId");
            CreateIndex("dbo.MasterLessons", "LessonId");
            CreateIndex("dbo.MasterLessons", "MasterId");
            AddForeignKey("dbo.MasterLessons", "LessonId", "dbo.Lessons", "LessonId", cascadeDelete: true);
            AddForeignKey("dbo.MasterLessons", "MasterId", "dbo.Masters", "MasterId", cascadeDelete: true);
        }
    }
}
