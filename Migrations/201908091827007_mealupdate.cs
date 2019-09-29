namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mealupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "IsSelect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "IsSelect", c => c.Boolean(nullable: false));
        }
    }
}
