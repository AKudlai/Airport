namespace Airport.DAL.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Airport.Models.DomainModels.Entities;

    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            this.HasKey(p => p.TicketNumber);
        }
    }
}
