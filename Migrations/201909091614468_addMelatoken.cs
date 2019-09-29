namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMelatoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentMeals", "MealToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentMeals", "MealToken");
        }
    }
}
