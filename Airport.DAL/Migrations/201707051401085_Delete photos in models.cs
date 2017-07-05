namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletephotosinmodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Aircraft", "Photo");
            DropColumn("dbo.Aircraft", "SitsPlan");
            DropColumn("dbo.Airlines", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Airlines", "Logo", c => c.Binary());
            AddColumn("dbo.Aircraft", "SitsPlan", c => c.Binary());
            AddColumn("dbo.Aircraft", "Photo", c => c.Binary());
        }
    }
}
