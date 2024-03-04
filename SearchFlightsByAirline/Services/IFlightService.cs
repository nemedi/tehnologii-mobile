namespace SearchFlightsByAirline.Services
{
    public interface IFlightService
    {
        Task<IList<Models.Flight>> GetFlightsByAirline(string airlineCode);
    }
}
