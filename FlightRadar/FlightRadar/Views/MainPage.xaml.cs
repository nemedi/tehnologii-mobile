namespace FlightRadar.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.FlightViewModel();
    }
}