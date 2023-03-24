using System.Windows.Input;

namespace Coins.ViewModels
{
    public class CoinsByCountryViewModel : BaseViewModel
    {
        string country;
        IList<Data.Coin> coins;
        public ICommand GoToCountriesCommand { get; private set; }
        public ICommand EditCoinCommand { get; private set; }

        public CoinsByCountryViewModel(Data.Database database) : base(database)
        {
            GoToCountriesCommand = new Command(
                async () => await Shell.Current.GoToAsync("//countries"));
            EditCoinCommand = new Command<string>(
                async (id) => await Shell.Current.GoToAsync($"//coin?id={id}"));
        }

        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    Coins = await Database.GetCoinsByCountryAsync(country);
                });
            }
        }

        public IList<Data.Coin> Coins
        {
            get => coins;
            set
            {
                coins = value;
                OnPropertyChanged();
            }
        }
    }
}
