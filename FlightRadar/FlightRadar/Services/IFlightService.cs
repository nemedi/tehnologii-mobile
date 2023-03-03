namespace FlightRadar.Services
{
    public interface IFlightsService
    {
        Task<IList<Models.Flight>> GetFlights();
    }
}
