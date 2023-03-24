namespace Coins.Pages;

public partial class CountriesPage : ContentPage
{
	public CountriesPage(ViewModels.CountriesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		(BindingContext as ViewModels.CountriesViewModel)
			.ShowCoinsByCountryCommand.Execute(e.SelectedItem as string);
    }
}