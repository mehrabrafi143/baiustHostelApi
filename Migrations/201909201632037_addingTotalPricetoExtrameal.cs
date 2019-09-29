namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTotalPricetoExtrameal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtraMeals", "TotalAmount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExtraMeals", "TotalAmount");
        }
    }
}
