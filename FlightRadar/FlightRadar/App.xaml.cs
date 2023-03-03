using FlightRadar.Services;

namespace FlightRadar;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		DependencyService.Register<FlightsService>();
		MainPage = new AppShell();
	}
}
