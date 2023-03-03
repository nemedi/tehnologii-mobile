using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.ViewModels
{
    public interface ICoinsByIssuerViewModel
    {
        Models.Issuer Issuer { set; }
        IList<Models.Coin> Coins { get; }
    }
}
