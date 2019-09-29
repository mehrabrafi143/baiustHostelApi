namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemeal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "Price", c => c.Single(nullable: false));
        }
    }
}
