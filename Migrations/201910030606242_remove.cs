namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "SitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "SitId", c => c.Int(nullable: false));
        }
    }
}
