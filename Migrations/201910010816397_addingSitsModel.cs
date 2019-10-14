namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSitsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        ElectricityBill = c.Single(nullable: false),
                        ElectricityBillPerHead = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Gender");
            DropTable("dbo.Sits");
        }
    }
}
