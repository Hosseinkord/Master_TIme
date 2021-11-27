namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeaSection3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        DateId = c.Int(nullable: false, identity: true),
                        DateName = c.String(),
                    })
                .PrimaryKey(t => t.DateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dates");
        }
    }
}
