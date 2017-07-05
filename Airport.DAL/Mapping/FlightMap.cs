namespace Airport.DAL.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Airport.Models.DomainModels.Entities;

    public class FlightMap : EntityTypeConfiguration<Flight>
    {
        public FlightMap()
        {
            this.HasKey(p => p.FlightNumber);
            this.HasMany(p => p.Tickets).WithMany(p => p.Flights).Map(
                m =>
                    {
                        m.MapLeftKey("TicketNumber");
                        m.MapRightKey("FlightNumber");
                    });
        }
    }
}
