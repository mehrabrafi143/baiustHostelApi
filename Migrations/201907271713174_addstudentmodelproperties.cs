namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstudentmodelproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RoomNo", c => c.String());
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "AddedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "AddedTime");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "RoomNo");
        }
    }
}
