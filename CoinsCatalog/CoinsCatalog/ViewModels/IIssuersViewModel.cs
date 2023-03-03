using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.ViewModels
{
    public interface IIssuersViewModel
    {
        IList<Models.Issuer> Issuers { get; }

        Task ReloadAsync();
    }
}
