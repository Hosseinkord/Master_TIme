namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Labrator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labrators",
                c => new
                    {
                        LabratorId = c.Int(nullable: false, identity: true),
                        DateId = c.Int(nullable: false),
                        Labrator_description = c.String(),
                        Empty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LabratorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Labrators");
        }
    }
}
