using System.ComponentModel;

namespace CoinsCatalog.ViewModels
{
    public class CoinsByIssuerViewModel : ICoinsByIssuerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Services.IDataService service;
        private IList<Models.Coin> coins = new List<Models.Coin>();

        public CoinsByIssuerViewModel(Services.IDataService service)
        {
            this.service = service;
        }

        public Models.Issuer Issuer
        {
            set
            {
                Dispatcher.GetForCurrentThread().Dispatch(async () =>
                {
                    Coins = await service.GetCoinsByIssuerAsync(value);
                });
            }
        }

        public IList<Models.Coin> Coins
        {
            get
            {
                return coins;
            }
            set
            {
                coins = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Coins)));
            }
        }

    }
}
