namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Model = c.String(),
                        Photo = c.Binary(),
                        SitsPlan = c.Binary(),
                        FirstClassSit = c.Int(nullable: false),
                        BusinessClassSit = c.Int(nullable: false),
                        EconomyClassSit = c.Int(nullable: false),
                        AirlineId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .Index(t => t.AirlineId);
            
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Logo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 128),
                        FlightType = c.Int(nullable: false),
                        FlightDate = c.DateTime(nullable: false),
                        PortId = c.Guid(nullable: false),
                        Terminal = c.String(),
                        Gate = c.Int(nullable: false),
                        AirlineId = c.Guid(nullable: false),
                        FlightStatusId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FlightNumber)
                .ForeignKey("dbo.Airlines", t => t.AirlineId, cascadeDelete: true)
                .ForeignKey("dbo.FlightStatus", t => t.FlightStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Ports", t => t.PortId, cascadeDelete: true)
                .Index(t => t.PortId)
                .Index(t => t.AirlineId)
                .Index(t => t.FlightStatusId);
            
            CreateTable(
                "dbo.FlightStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Photo = c.Binary(),
                        Country = c.String(),
                        LocalityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketNumber = c.Guid(nullable: false),
                        CabinClass = c.Int(nullable: false),
                        SitNumber = c.String(),
                        PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.TicketNumber)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirsday = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        Nationality = c.String(),
                        PassportSerial = c.String(),
                        PassportIssueDate = c.DateTime(nullable: false),
                        PassportExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FlightTickets",
                c => new
                    {
                        TicketNumber = c.String(nullable: false, maxLength: 128),
                        FlightNumber = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TicketNumber, t.FlightNumber })
                .ForeignKey("dbo.Flights", t => t.TicketNumber, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.FlightNumber, cascadeDelete: true)
                .Index(t => t.TicketNumber)
                .Index(t => t.FlightNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightTickets", "FlightNumber", "dbo.Tickets");
            DropForeignKey("dbo.FlightTickets", "TicketNumber", "dbo.Flights");
            DropForeignKey("dbo.Prices", "Id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "PersonId", "dbo.People");
            DropForeignKey("dbo.Flights", "PortId", "dbo.Ports");
            DropForeignKey("dbo.Flights", "FlightStatusId", "dbo.FlightStatus");
            DropForeignKey("dbo.Flights", "AirlineId", "dbo.Airlines");
            DropForeignKey("dbo.Aircraft", "AirlineId", "dbo.Airlines");
            DropIndex("dbo.FlightTickets", new[] { "FlightNumber" });
            DropIndex("dbo.FlightTickets", new[] { "TicketNumber" });
            DropIndex("dbo.Prices", new[] { "Id" });
            DropIndex("dbo.Tickets", new[] { "PersonId" });
            DropIndex("dbo.Flights", new[] { "FlightStatusId" });
            DropIndex("dbo.Flights", new[] { "AirlineId" });
            DropIndex("dbo.Flights", new[] { "PortId" });
            DropIndex("dbo.Aircraft", new[] { "AirlineId" });
            DropTable("dbo.FlightTickets");
            DropTable("dbo.Prices");
            DropTable("dbo.People");
            DropTable("dbo.Tickets");
            DropTable("dbo.Ports");
            DropTable("dbo.FlightStatus");
            DropTable("dbo.Flights");
            DropTable("dbo.Airlines");
            DropTable("dbo.Aircraft");
        }
    }
}
