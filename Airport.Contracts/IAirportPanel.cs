namespace Airport.Contracts
{
    using System.Collections.Generic;

    using Airport.Models.DomainModels.ViewModels;
    using Airport.Models.ViewModels;

    public interface IFlightPanel
    {
        IEnumerable<FlightPanelView> GetFlights();

        void AddFlight(FlightPanelView flight);

        void EditFlight(FlightPanelView flight);

        void DeleteFlight(FlightPanelView flight);
    }
}
