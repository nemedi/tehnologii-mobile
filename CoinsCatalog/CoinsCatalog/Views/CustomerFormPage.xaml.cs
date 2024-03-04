namespace CoinsCatalog.Views;

public partial class CustomerFormPage : ContentPage
{
	public CustomerFormPage(ViewModels.CustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}