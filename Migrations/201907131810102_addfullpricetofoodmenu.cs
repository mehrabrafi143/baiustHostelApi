namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfullpricetofoodmenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodMenus", "FullPrice", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodMenus", "FullPrice");
        }
    }
}
