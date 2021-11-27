namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        MasterId = c.Int(nullable: false, identity: true),
                        MasterCode = c.Int(nullable: false),
                        MasterName = c.String(),
                        NumLesson = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MasterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Masters");
        }
    }
}
