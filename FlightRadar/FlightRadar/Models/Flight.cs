namespace FlightRadar.Models
{
    public class Flight
    {
        public string Code { get; private set; }

        public string Origin { get; private set; }

        public string Destination { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Aircraft { get; private set; }

        public string Airline { get; private set; }

        public Flight(string code,
            double latitude,
            double longitude,
            string origin,
            string destination,
            string aircraft,
            string airline)
        {
            Code = code;
            Latitude = latitude;
            Longitude = longitude;
            Origin = origin;
            Destination = destination;
            Aircraft = aircraft;
            Airline = airline;
        }
    }
}
