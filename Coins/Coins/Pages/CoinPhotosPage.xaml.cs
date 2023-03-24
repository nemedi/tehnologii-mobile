namespace Coins.Pages;

public partial class CoinPhotosPage : TabbedPage, IQueryAttributable
{
	public CoinPhotosPage(ViewModels.CoinPhotosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		(BindingContext as ViewModels.CoinPhotosViewModel).Id = query["id"] as string;
    }
}