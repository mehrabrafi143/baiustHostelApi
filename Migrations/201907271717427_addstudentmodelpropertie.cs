namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudentmodelpropertie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PhoneNumber");
        }
    }
}
