using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.Data
{
    public interface IRepository
    {
        Task SaveCoinsAsync(IEnumerable<Models.Coin> coins);

        Task<List<Models.Issuer>> GetIssuersAsync();

        Task<List<Models.Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer);
    }
}
