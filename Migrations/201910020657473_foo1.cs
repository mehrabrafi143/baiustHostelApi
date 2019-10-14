namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sits", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.Sits", name: "IX_Gender_Id", newName: "IX_GenderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sits", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.Sits", name: "GenderId", newName: "Gender_Id");
        }
    }
}
