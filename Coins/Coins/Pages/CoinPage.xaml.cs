namespace Coins.Pages;

public partial class CoinPage : ContentPage, IQueryAttributable
{
	public CoinPage(ViewModels.CoinViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        (BindingContext as ViewModels.CoinViewModel).Id = query["id"] as string;
    }
}