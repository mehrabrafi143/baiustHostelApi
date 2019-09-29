namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingExtraMeals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraMeals",
                c => new
                    {
                        MealId = c.Int(nullable: false),
                        Numbers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealId, t.Numbers });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExtraMeals");
        }
    }
}
