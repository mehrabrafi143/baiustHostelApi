namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingendertosit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sits", "Gender_Id", c => c.Int());
            CreateIndex("dbo.Sits", "Gender_Id");
            AddForeignKey("dbo.Sits", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sits", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Sits", new[] { "Gender_Id" });
            DropColumn("dbo.Sits", "Gender_Id");
        }
    }
}
