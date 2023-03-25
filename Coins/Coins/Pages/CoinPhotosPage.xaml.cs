namespace Coins.Pages;

public partial class CoinPhotosPage : ContentPage, IQueryAttributable
{
	public CoinPhotosPage(ViewModels.CoinPhotosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		(BindingContext as ViewModels.CoinPhotosViewModel).Id = query["id"] as string;
        (BindingContext as ViewModels.CoinPhotosViewModel).New = bool.Parse(query["new"] as string);
    }
}