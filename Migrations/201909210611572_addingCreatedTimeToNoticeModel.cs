namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingCreatedTimeToNoticeModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Notics", newName: "Notices");
            AddColumn("dbo.Notices", "CreatedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notices", "CreatedTime");
            RenameTable(name: "dbo.Notices", newName: "Notics");
        }
    }
}
