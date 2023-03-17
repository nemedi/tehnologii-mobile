using System.ComponentModel;

namespace FlightRadar.ViewModels
{
    public interface IFlightRadarViewModel : INotifyPropertyChanged
    {
        IList<Models.Flight> Flights { get; }
    }
}
