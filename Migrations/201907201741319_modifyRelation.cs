namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserAccountId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "UserAccountId");
        }
    }
}
