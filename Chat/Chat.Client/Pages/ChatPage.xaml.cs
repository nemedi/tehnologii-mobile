namespace Chat.Client.Pages;

public partial class ChatPage : ContentPage, IQueryAttributable
{
	public ChatPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is ViewModels.ChatViewModel viewModel)
        {
            viewModel.User = query["user"] as string;
            viewModel.Endpoint = query["endpoint"] as string;
        }
    }
}