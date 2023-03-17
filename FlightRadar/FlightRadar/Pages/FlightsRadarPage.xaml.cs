namespace FlightRadar.Pages;

public partial class FlightsRadarPage : ContentPage
{
	public FlightsRadarPage(ViewModels.IFlightRadarViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}