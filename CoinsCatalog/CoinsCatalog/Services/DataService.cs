using CoinsCatalog.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoinsCatalog.Services
{
    public class DataService : IDataService
    {
        private Data.IRepository repository;
        public DataService(Data.IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer)
        {
            return await repository.GetCoinsByIssuerAsync(issuer);
        }

        public async Task<IList<Models.Issuer>> GetIssuersAsync()
        {
            var issuers = await repository.GetIssuersAsync();
            if (issuers.Count == 0)
            {
                await ReloadAsync();
                issuers = await repository.GetIssuersAsync();
            }
            return issuers;
        }

        public async Task ReloadAsync()
        {
            const string apyKey = Utilities.Constants.ApiKey;
            var authentication = await AuthenticateAsync(apyKey);
            var coins = await GetCoinsAsync(authentication, apyKey);
            await repository.SaveCoinsAsync(coins);
        }

        private async Task<Models.Authentication> AuthenticateAsync(string apiKey)
        {
            var endpoint = "https://api.numista.com/api/v3/oauth_token?grant_type=client_credentials&scope=view_collection";
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Add("Numista-API-Key", apiKey);
                    var response = await client.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic data = JObject.Parse(content);
                    return new Models.Authentication
                    {
                        Token = data?.access_token,
                        UserId = data?.user_id
                    };
                }
            }
        }

        private async Task<IEnumerable<Models.Coin>> GetCoinsAsync(Models.Authentication authentication, string apiKey)
        {
            var endpoint = $"https://api.numista.com/api/v3/users/{authentication.UserId}/collected_items?category=coin";
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Add("Numista-API-Key", apiKey);
                    request.Headers.Add("Authorization", $"Bearer {authentication.Token}");
                    var response = await client.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic data = JObject.Parse(content);
                    var coins = new List<Models.Coin>();
                    foreach (var item in data?.items)
                    {
                        long? id = item?.id;
                        string? description = item?.type?.title;
                        string? issuer = item?.type?.issuer?.name;
                        string? issue = item?.issue?.gregorian_year;
                        string? grade = item?.grade;
                        if (id.HasValue)
                        {
                            coins.Add(new Models.Coin
                            {
                                Id = id.Value,
                                Description = description,
                                Issuer = issuer,
                                Issue = issue,
                                Grade = grade
                            });
                        }
                    }
                    return coins;
                }
            }
        }
    }
}
