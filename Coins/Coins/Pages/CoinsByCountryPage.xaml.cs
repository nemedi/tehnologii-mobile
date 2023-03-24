namespace Coins.Pages;

public partial class CoinsByCountryPage : ContentPage, IQueryAttributable
{
    public CoinsByCountryPage(ViewModels.CoinsByCountryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        (BindingContext as ViewModels.CoinsByCountryViewModel).Country = query["country"] as string;
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        (BindingContext as ViewModels.CoinsByCountryViewModel)
			.EditCoinCommand.Execute((e.SelectedItem as Data.Coin).Id);
    }
}