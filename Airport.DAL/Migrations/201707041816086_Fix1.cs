namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FlightTickets", new[] { "FlightNumber" });
            DropIndex("dbo.FlightTickets", new[] { "TicketNumber" });
            RenameColumn(table: "dbo.FlightTickets", name: "FlightNumber", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FlightTickets", name: "TicketNumber", newName: "FlightNumber");
            RenameColumn(table: "dbo.FlightTickets", name: "__mig_tmp__0", newName: "TicketNumber");
            DropPrimaryKey("dbo.FlightTickets");
            AlterColumn("dbo.FlightTickets", "FlightNumber", c => c.Guid(nullable: false));
            AlterColumn("dbo.FlightTickets", "TicketNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FlightTickets", new[] { "TicketNumber", "FlightNumber" });
            CreateIndex("dbo.FlightTickets", "TicketNumber");
            CreateIndex("dbo.FlightTickets", "FlightNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FlightTickets", new[] { "FlightNumber" });
            DropIndex("dbo.FlightTickets", new[] { "TicketNumber" });
            DropPrimaryKey("dbo.FlightTickets");
            AlterColumn("dbo.FlightTickets", "TicketNumber", c => c.Guid(nullable: false));
            AlterColumn("dbo.FlightTickets", "FlightNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FlightTickets", new[] { "FlightNumber", "TicketNumber" });
            RenameColumn(table: "dbo.FlightTickets", name: "TicketNumber", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FlightTickets", name: "FlightNumber", newName: "TicketNumber");
            RenameColumn(table: "dbo.FlightTickets", name: "__mig_tmp__0", newName: "FlightNumber");
            CreateIndex("dbo.FlightTickets", "TicketNumber");
            CreateIndex("dbo.FlightTickets", "FlightNumber");
        }
    }
}
