namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Labratoryy : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Labrators", newName: "Labratoryies");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Labratoryies", newName: "Labrators");
        }
    }
}
