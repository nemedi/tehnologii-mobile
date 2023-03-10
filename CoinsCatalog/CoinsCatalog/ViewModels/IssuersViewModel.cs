namespace CoinsCatalog.ViewModels
{
    public class IssuersViewModel : IIssuersViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Services.IDataService service;
        private IList<Models.Issuer> issuers = new List<Models.Issuer>();

        public IssuersViewModel(Services.IDataService service)
        {
            this.service = service;
			LoadIssuers();
        }

        public async Task ReloadAsync()
        {
            await service.ReloadAsync();
			LoadIssuers();
        }

        public IList<Models.Issuer> Issuers
        {
            get
            {
                return issuers;
            }
            set
            {
                issuers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Issuers)));
            }
        }
		
		private void LoadIssuers()
		{
			Dispatcher.GetForCurrentThread().Dispatch(async () =>
            {
                Issuers = await service.GetIssuersAsync();
            });
		}

    }
}
