using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FlightRadar.Services
{
    public class FlightsService : IFlightsService
    {
        const string flightsEndpoint = "https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&bounds=49.381%2C42.022%2C19.324%2C32.056&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400&gliders=1&stats=1";
        const string flightEndpoint = "https://data-live.flightradar24.com/clickhandler/?flight=";
        const double distance = 100;
        private Location location;

        async public Task<IList<Models.Flight>> GetFlights()
        {
            if (location is null)
            {
                location = await Geolocation.GetLocationAsync();
            }
            var flights = new List<Models.Flight>();
            using (var client = new HttpClient())
            {
                var body = await client.GetStringAsync(flightsEndpoint);
                JObject flightsJson = JObject.Parse(body);
                foreach (var entry in flightsJson)
                {
                    if (entry.Key != "full_count" && entry.Key != "version" && entry.Value is JArray)
                    {
                        double latitude = (double)(entry.Value as JArray)[1];
                        double longitude = (double)(entry.Value as JArray)[2];
                        if (location.CalculateDistance(
                            new Location(latitude, longitude), DistanceUnits.Kilometers) <= distance)
                        {
                            body = await client.GetStringAsync(flightEndpoint + entry.Key);
                            var flightJson = JObject.Parse(body);
                            string origin = flightJson["airport"] is JObject
                                && (flightJson["airport"] as JObject)["origin"] is JObject
                                && ((flightJson["airport"] as JObject)["origin"] as JObject).ContainsKey("name")
                                ? (string)((flightJson["airport"] as JObject)["origin"] as JObject)["name"]
                                : "";
                            string destination = flightJson["airport"] is JObject
                                && (flightJson["airport"] as JObject)["destination"] is JObject
                                && ((flightJson["airport"] as JObject)["destination"] as JObject).ContainsKey("name")
                                ? (string)((flightJson["airport"] as JObject)["destination"] as JObject)["name"]
                                : "";
                            string aircraft = flightJson["aircraft"] is JObject
                                && (flightJson["aircraft"] as JObject)["model"] is JObject
                                && ((flightJson["aircraft"] as JObject)["model"] as JObject).ContainsKey("text")
                                ? (string)((flightJson["aircraft"] as JObject)["model"] as JObject)["text"]
                                : "";
                            string airline = flightJson["airline"] is JObject
                                && (flightJson["airline"] as JObject).ContainsKey("name")
                                ? (string)(flightJson["airline"] as JObject)["name"]
                                : "";
                            flights.Add(new Models.Flight
                                {
                                    Aircraft = aircraft ?? "",
                                    Airline = airline ?? "",
                                    Destination = destination ?? "",
                                    Origin = origin ?? ""
                                }
                            );
                        }
                    }
                }
            }
            return flights;
        }
    }
}
