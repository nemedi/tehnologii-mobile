using Newtonsoft.Json.Linq;
using FlightRadar.Utilities;

namespace FlightRadar.Services
{
    public class FlightsService : IFlightsService
    {
        const string flightsEndpoint = "https://data-live.flightradar24.com/zones/fcgi/feed.js";
        const string flightEndpoint = "https://data-live.flightradar24.com/clickhandler/?flight=";
        const double distance = 100;

        private bool initialized;
        private double latitude;
        private double longitude;

        public async Task<IList<Models.Flight>> GetFlights()
        {
            if (!initialized)
            {
                var location = await Geolocation.GetLocationAsync();
                latitude = location.Latitude;
                longitude = location.Longitude;
                initialized = true;
            }
            var flights = new List<Models.Flight>();
            foreach (var property in await GetJson(flightsEndpoint))
            {
                if (property.Key != "full_count" && property.Key != "version")
                {
                    var flightBasicDetails = property.Value as JArray;
                    string code = property.Key;
                    double latitude = (double)flightBasicDetails[1];
                    double longitude = (double)flightBasicDetails[2];
                    if (DistanceBetween(this.latitude,
                        this.longitude,
                        latitude,
                        longitude) <= distance * 1000)
                    {
                        var flightAdditionalDetails = await GetJson(flightEndpoint + code);
                        var origin = flightAdditionalDetails.GetValue<string>("airport", "origin", "name");
                        var destination = flightAdditionalDetails.GetValue<string>("airport", "destination", "name");
                        var aircraft = flightAdditionalDetails.GetValue<string>("aircraft", "model", "text");
                        var airline = flightAdditionalDetails.GetValue<string>("airline", "name");
                        flights.Add(new Models.Flight(code, latitude, longitude, origin, destination, aircraft, airline));
                    }
                }
            }

            return flights;
        }

        private async Task<JObject> GetJson(string endpoint)
        {
            return JObject.Parse(await new HttpClient().GetStringAsync(endpoint));

        }

        private static double DistanceBetween(double sourceLatitude,
           double sourceLongitute, double destinationLatitude,
            double destinationLongitude)
        {
            double R = 6378137;
            double dLat = (destinationLatitude - sourceLatitude) * Math.PI / 180;
            double dLng = (destinationLongitude - sourceLongitute) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                    + Math.Cos(sourceLatitude * Math.PI / 180)
                    * Math.Cos(destinationLatitude * Math.PI / 180)
                    * Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return Math.Round(d);
        }
    }
}
