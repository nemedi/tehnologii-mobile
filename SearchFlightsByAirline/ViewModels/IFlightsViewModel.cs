using System.ComponentModel;

namespace SearchFlightsByAirline.ViewModels
{
    public interface IFlightsViewModel : INotifyPropertyChanged
    {
        string Airline { get; set; }

        bool Busy { get; set; }

        bool HasFlights { get; set; }

        bool HasNoFlights { get; set; }

        IList<Models.Flight> Flights { get; set; }

        Task SearchFlights(string airline);

        void ClearResults();
    }
}
