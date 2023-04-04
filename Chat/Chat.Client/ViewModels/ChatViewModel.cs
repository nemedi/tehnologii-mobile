using Essentials.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Chat.Client.ViewModels
{
    public class ChatViewModel : ObservableObject
    {
        Services.ChatService service;
        string content = string.Empty;

        public ObservableCollection<Models.Message> Messages { get; set; } = new ObservableCollection<Models.Message>();
        public ICommand SendMessageCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public string User { get; set; }
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }

        public ChatViewModel()
        {
            service = new Services.ChatService();
            service.MessageReceived += OnMessageReceived;
            SendMessageCommand = new Command(async () => await OnSendMessageAsync());
            LogoutCommand = new Command(async () => await OnLogoutAsync());
        }

        public string Endpoint {
            set
            {
                service.Login(User, value);
            }
        }
        
        void OnMessageReceived(Models.Message message)
        {
            Messages.Add(message);
        }

        async Task OnSendMessageAsync()
        {
            await service?.SendMessageAsync(Content);
            Content = string.Empty;
        }

        async Task OnLogoutAsync()
        {
            await Shell.Current.GoToAsync("//login");
        }

    }
}
