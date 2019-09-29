namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNotificationAndUsernotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(),
                        OriginalTitle = c.String(),
                        OriginalDescription = c.String(),
                        NotificationType = c.Int(nullable: false),
                        Notice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notices", t => t.Notice_Id)
                .Index(t => t.Notice_Id);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "StudentId", "dbo.Students");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Notice_Id", "dbo.Notices");
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "StudentId" });
            DropIndex("dbo.Notifications", new[] { "Notice_Id" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
