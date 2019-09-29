namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiePricepropertie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodMenus", "ServicePrice", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodMenus", "ServicePrice");
        }
    }
}
