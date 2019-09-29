namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplifyStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "PaidAmount", c => c.Single());
            AlterColumn("dbo.Students", "DeuAmount", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DeuAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Students", "PaidAmount", c => c.Single(nullable: false));
        }
    }
}
