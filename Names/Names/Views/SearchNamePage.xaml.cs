namespace Names.Views;

public partial class SearchNamePage : ContentPage
{
    public SearchNamePage(ViewModels.ISearchNameViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    private void ExitToolbarItem_Clicked(object sender, EventArgs e)
    {
		Application.Current.Quit();
    }

    private async void SearchButton_Clicked(object sender, EventArgs e)
    {
        await (BindingContext as ViewModels.ISearchNameViewModel).SearchName();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as ViewModels.ISearchNameViewModel).ClearResults();
    }
}