namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSitsModelWithOccupiedSit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sits", "OccupiedSit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sits", "OccupiedSit");
        }
    }
}
