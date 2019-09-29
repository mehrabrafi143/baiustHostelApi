namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserImages");
        }
    }
}
