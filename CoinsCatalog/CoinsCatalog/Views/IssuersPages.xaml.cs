namespace CoinsCatalog.Views;

public partial class IssuersPage : ContentPage
{
	public IssuersPage(ViewModels.IIssuersViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    async void OnReload(object sender, EventArgs e)
    {
        await (BindingContext as ViewModels.IIssuersViewModel).ReloadAsync();
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var issuer = e.SelectedItem as Models.Issuer;
        var parameters = new Dictionary<string, object>();
        parameters["Issuer"] = issuer;
        await Shell.Current.GoToAsync("//coinsByIssuer", parameters);
    }
}