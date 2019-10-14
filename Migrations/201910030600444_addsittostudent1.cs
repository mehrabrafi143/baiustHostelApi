namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsittostudent1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Sit_Id1", "dbo.Sits");
            DropIndex("dbo.Students", new[] { "Sit_Id1" });
            DropColumn("dbo.Students", "Sit_Id");
            DropColumn("dbo.Students", "Sit_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Sit_Id1", c => c.Int());
            AddColumn("dbo.Students", "Sit_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Sit_Id1");
            AddForeignKey("dbo.Students", "Sit_Id1", "dbo.Sits", "Id");
        }
    }
}
