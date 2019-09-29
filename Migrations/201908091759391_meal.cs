namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        IsSelect = c.Boolean(nullable: false),
                        FoodMenu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodMenus", t => t.FoodMenu_Id)
                .Index(t => t.FoodMenu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "FoodMenu_Id", "dbo.FoodMenus");
            DropIndex("dbo.Meals", new[] { "FoodMenu_Id" });
            DropTable("dbo.Meals");
        }
    }
}
