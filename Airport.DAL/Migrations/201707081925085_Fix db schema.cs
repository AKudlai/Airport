namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixdbschema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aircraft", "AirlineId", "dbo.Airlines");
            DropIndex("dbo.Aircraft", new[] { "AirlineId" });
            CreateTable(
                "dbo.AircraftAirlines",
                c => new
                    {
                        AirlineId = c.Guid(nullable: false),
                        AicraftId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AirlineId, t.AicraftId })
                .ForeignKey("dbo.Aircraft", t => t.AirlineId, cascadeDelete: true)
                .ForeignKey("dbo.Airlines", t => t.AicraftId, cascadeDelete: true)
                .Index(t => t.AirlineId)
                .Index(t => t.AicraftId);
            
            AddColumn("dbo.Aircraft", "FirstClassSitCount", c => c.Int(nullable: false));
            AddColumn("dbo.Aircraft", "BusinessClassSitCount", c => c.Int(nullable: false));
            AddColumn("dbo.Aircraft", "EconomyClassSitCount", c => c.Int(nullable: false));
            DropColumn("dbo.Aircraft", "FirstClassSit");
            DropColumn("dbo.Aircraft", "BusinessClassSit");
            DropColumn("dbo.Aircraft", "EconomyClassSit");
            DropColumn("dbo.Aircraft", "AirlineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aircraft", "AirlineId", c => c.Guid(nullable: false));
            AddColumn("dbo.Aircraft", "EconomyClassSit", c => c.Int(nullable: false));
            AddColumn("dbo.Aircraft", "BusinessClassSit", c => c.Int(nullable: false));
            AddColumn("dbo.Aircraft", "FirstClassSit", c => c.Int(nullable: false));
            DropForeignKey("dbo.AircraftAirlines", "AicraftId", "dbo.Airlines");
            DropForeignKey("dbo.AircraftAirlines", "AirlineId", "dbo.Aircraft");
            DropIndex("dbo.AircraftAirlines", new[] { "AicraftId" });
            DropIndex("dbo.AircraftAirlines", new[] { "AirlineId" });
            DropColumn("dbo.Aircraft", "EconomyClassSitCount");
            DropColumn("dbo.Aircraft", "BusinessClassSitCount");
            DropColumn("dbo.Aircraft", "FirstClassSitCount");
            DropTable("dbo.AircraftAirlines");
            CreateIndex("dbo.Aircraft", "AirlineId");
            AddForeignKey("dbo.Aircraft", "AirlineId", "dbo.Airlines", "Id", cascadeDelete: true);
        }
    }
}
