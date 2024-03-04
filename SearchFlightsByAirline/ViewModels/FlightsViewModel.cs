using SearchFlightsByAirline.Models;
using SearchFlightsByAirline.Services;
using System.ComponentModel;

namespace SearchFlightsByAirline.ViewModels
{
    public class FlightsViewModel : IFlightsViewModel
    {
        IFlightService service;
        IList<Models.Flight> flights = new List<Models.Flight>();
        bool busy;
        bool hasFlights;
        bool hasNoFlights;

        public FlightsViewModel(Services.IFlightService service)
        {
            this.service = service;
        }

        public string Airline { get; set; }

        public bool Busy
        {
            get
            {
                return busy;
            }
            set
            {
                busy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Busy)));
            }
        }

        public bool HasFlights
        {
            get
            {
                return hasFlights;
            }
            set
            {
                hasFlights = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasFlights)));
            }
        }

        public bool HasNoFlights
        {
            get
            {
                return hasNoFlights;
            }
            set
            {
                hasNoFlights = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasNoFlights)));
            }
        }

        public IList<Flight> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
                HasFlights = flights?.Count > 0;
                HasNoFlights = flights?.Count == 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flights)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ClearResults()
        {
            Flights.Clear();
        }

        public async Task SearchFlights(string airline)
        {
            Busy = true;
            Flights = await service.GetFlightsByAirline(airline);
            Busy = false;
        }
    }
}
