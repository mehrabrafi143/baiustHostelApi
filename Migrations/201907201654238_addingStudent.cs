namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Roll = c.Int(nullable: false),
                        PaidAmount = c.Single(nullable: false),
                        DeuAmount = c.Single(nullable: false),
                        UserAccount_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UserAccount_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "UserAccount_Id" });
            DropTable("dbo.Students");
        }
    }
}
