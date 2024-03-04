using Newtonsoft.Json.Linq;

namespace SearchFlightsByAirline.Services
{
    public class FlightService : IFlightService
    {
        public async Task<IList<Models.Flight>> GetFlightsByAirline(string airlineCode)
        {
            var flights = new List<Models.Flight>();
            using (var client = new HttpClient()) {
                var body = await client.GetStringAsync(Utilities.Constants.FlightsEndpoint + airlineCode.ToUpper());
                JObject flightsResult = JObject.Parse(body);
                foreach (var property in flightsResult.Properties())
                {
                    if (property.Value is JArray)
                    {
                        body = await client.GetStringAsync(Utilities.Constants.FlightEndpoint + property.Name);
                        dynamic flightResult = JObject.Parse(body);
                        var flight = new Models.Flight
                        {
                            Status = flightResult?.status?.text,
                            Origin = flightResult?.airport?.origin?.name,
                            Destination = flightResult?.airport?.destination?.name,
                            Aircraft = flightResult?.aircraft?.model?.text
                        };
                        flights.Add(flight);
                    }
                }
            }
            return flights;
        }
    }
}
