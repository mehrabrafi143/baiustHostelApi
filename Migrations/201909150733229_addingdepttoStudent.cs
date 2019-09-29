namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdepttoStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Dept", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Dept");
        }
    }
}
