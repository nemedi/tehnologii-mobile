using System.ComponentModel;

namespace FlightRadar.ViewModels
{
    public class FlightViewModel : INotifyPropertyChanged
    {
        private IList<Models.Flight> flights;
        private Services.IFlightsService service;

        public FlightViewModel()
        {
            service = DependencyService.Resolve<Services.IFlightsService>();
            flights = new List<Models.Flight>();
            Dispatcher.GetForCurrentThread().StartTimer(new TimeSpan(0, 0, 10), () =>
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
