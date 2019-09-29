namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuAndStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodMenus", "FullPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.FoodMenus", "ServicePrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Students", "PaidAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Students", "DeuAmount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DeuAmount", c => c.Single());
            AlterColumn("dbo.Students", "PaidAmount", c => c.Single());
            AlterColumn("dbo.FoodMenus", "ServicePrice", c => c.Single());
            AlterColumn("dbo.FoodMenus", "FullPrice", c => c.Single());
        }
    }
}
