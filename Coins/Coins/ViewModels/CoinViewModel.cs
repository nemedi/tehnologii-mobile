using System.Windows.Input;

namespace Coins.ViewModels
{
    public class CoinViewModel : BaseViewModel
    {
        Data.Coin coin = new();
        bool isNew = false;
        public ICommand ShowCoinPhotos { get; private set; }
        public ICommand SaveCoin { get; private set; }
        public ICommand RemoveCoin { get; private set; }
        public ICommand CancelCoin { get; private set; }

        public CoinViewModel(Data.Database database) : base(database)
        {
            ShowCoinPhotos = new Command(
                async () => await Shell.Current.GoToAsync($"//coinPhotos?id={Coin.Id}&new={IsNew}"));
            SaveCoin = new Command(
                async () => {
                    await Database.SaveCoinAsync(Coin);
                    await GoBackAsync();
                });
            RemoveCoin = new Command(
                async () => {
                    if (coin?.Id is not null)
                    {
                        await Database.RemoveCoinAsync(Coin);
                        await GoBackAsync();
                    }
                });
            CancelCoin = new Command(
                async () => await GoBackAsync());
        }

        Data.Coin Coin
        {
            get => coin;
            set
            {
                coin = value;
                OnPropertyChanged();
            }
        }

        public string Id
        {
            get => coin?.Id;
            set
            {
                if (!IsNew)
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        Coin = await Database.GetCoinById(value);
                    });
                }
            }
        }

        public bool IsNew
        {
            get => isNew;
            set
            {
                isNew = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeRemoved => !IsNew;

        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync(Coin.New
                            ? "//countries"
                            : $"//coins?country={Coin.Country}");
        }

    }
}
