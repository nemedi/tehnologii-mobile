using System.ComponentModel;

namespace FlightRadar.ViewModels
{
    public class FlightViewModel : IFlightRadarViewModel
    {
        private IList<Models.Flight> flights;

        public FlightViewModel(Services.IFlightsService service)
        {
            Dispatcher.GetForCurrentThread().StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    Flights = await service.GetFlights();
                });
                return true;
            });
        }

        public IList<Models.Flight> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flights)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
