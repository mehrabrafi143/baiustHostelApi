namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignorForginKeuNoticeAndNotification : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Notifications", new[] { "Notice_Id" });
            AlterColumn("dbo.Notifications", "Notice_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "Notice_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notifications", new[] { "Notice_Id" });
            AlterColumn("dbo.Notifications", "Notice_Id", c => c.Int());
            CreateIndex("dbo.Notifications", "Notice_Id");
        }
    }
}
