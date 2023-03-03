using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection.Metadata;

namespace CoinsCatalog.Services
{
    public interface IDataService
    {
        Task ReloadAsync();

        Task<IList<Models.Issuer>> GetIssuersAsync();

        Task<IList<Models.Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer);
    }
}
