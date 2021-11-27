namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeASection6Help : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Class1", newName: "Helps");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Helps", newName: "Class1");
        }
    }
}
