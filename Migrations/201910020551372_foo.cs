namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.Students", name: "IX_Gender_Id", newName: "IX_GenderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.Students", name: "GenderId", newName: "Gender_Id");
        }
    }
}
