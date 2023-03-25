using System.Windows.Input;

namespace Coins.ViewModels
{
    public class CountriesViewModel : BaseViewModel
    {
        private IList<string> countries;
        public ICommand AddCoinCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }
        public ICommand ShowCoinsByCountryCommand { get; private set; }

        public CountriesViewModel(Data.Database databse) : base(databse)
        {
            AddCoinCommand = new Command(
                async () => await Shell.Current.GoToAsync("//coin?new=true"));
            ExitCommand = new Command(
                () => Application.Current.Quit());
            ShowCoinsByCountryCommand = new Command<string>(
                async (country) => await Shell.Current.GoToAsync($"//coins?country={country}"));
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Countries = await Database.GetCountriesAsync();
            });
        }

        public IList<string> Countries
        {
            get => countries;
            set
            {
                countries = value;
                OnPropertyChanged();
            }
        }

    }
}
