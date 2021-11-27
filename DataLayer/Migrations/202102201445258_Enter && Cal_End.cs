namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnterCal_End : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cal_End",
                c => new
                    {
                        Cal_EndId = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        Master = c.Int(nullable: false),
                        Lesson = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cal_EndId);
            
            CreateTable(
                "dbo.Enters",
                c => new
                    {
                        EnterId = c.Int(nullable: false, identity: true),
                        startTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        NumTerm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enters");
            DropTable("dbo.Cal_End");
        }
    }
}
