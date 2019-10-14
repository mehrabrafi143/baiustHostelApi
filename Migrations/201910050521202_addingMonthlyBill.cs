namespace BaiustHostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingMonthlyBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomBill = c.Single(nullable: false),
                        ServicePrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonthlyBills");
        }
    }
}
