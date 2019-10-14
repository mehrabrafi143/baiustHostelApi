namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinggender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Sits", "Gender");
            DropColumn("dbo.Students", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Sits", "Gender", c => c.Int(nullable: false));
            DropTable("dbo.Genders");
        }
    }
}
