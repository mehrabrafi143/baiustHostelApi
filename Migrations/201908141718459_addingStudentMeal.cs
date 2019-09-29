namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStudentMeal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentMeals",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.MealId })
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMeals", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentMeals", "MealId", "dbo.Meals");
            DropIndex("dbo.StudentMeals", new[] { "MealId" });
            DropIndex("dbo.StudentMeals", new[] { "StudentId" });
            DropTable("dbo.StudentMeals");
        }
    }
}
