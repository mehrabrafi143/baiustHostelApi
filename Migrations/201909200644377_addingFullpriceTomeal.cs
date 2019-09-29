namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFullpriceTomeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "FullPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "FullPrice");
        }
    }
}
