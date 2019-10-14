namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsittostudent11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "SitId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SitId");
        }
    }
}
