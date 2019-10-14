namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingendertostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Gender_Id", c => c.Int());
            CreateIndex("dbo.Students", "Gender_Id");
            AddForeignKey("dbo.Students", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Students", new[] { "Gender_Id" });
            DropColumn("dbo.Students", "Gender_Id");
        }
    }
}
