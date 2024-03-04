namespace SearchFlightsByAirline.Views;

public partial class FlightsPage : ContentPage
{
	public FlightsPage(ViewModels.IFlightsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    private void ExitToolbarItem_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private void AirlineEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as ViewModels.IFlightsViewModel).ClearResults();
    }

    private void SearchButton_Clicked(object sender, EventArgs e)
    {
        var airline = (BindingContext as ViewModels.IFlightsViewModel).Airline;
        (BindingContext as ViewModels.IFlightsViewModel).SearchFlights(airline);
    }
}