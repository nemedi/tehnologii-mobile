using System.Windows.Input;

namespace Chat.Client.ViewModels
{
    public class LoginViewModel
    {
        public string User { get; set; }
        public string Endpoint { get; set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginAsync());
            ExitCommand = new Command(OnExit);
        }

        async Task OnLoginAsync()
        {
            var query = new Dictionary<string, object>();
            query["user"] = User;
            query["endpoint"] = Endpoint;
            await Shell.Current.GoToAsync("//chat", query);
        }

        void OnExit()
        {
            Application.Current.Quit();
        }
    }
}
