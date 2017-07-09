namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletepriceentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "Id", "dbo.Tickets");
            DropIndex("dbo.Prices", new[] { "Id" });
            AddColumn("dbo.Tickets", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.Prices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Tickets", "Price");
            CreateIndex("dbo.Prices", "Id");
            AddForeignKey("dbo.Prices", "Id", "dbo.Tickets", "TicketNumber");
        }
    }
}
