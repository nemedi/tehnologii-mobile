using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.ViewModels
{
    public interface ICoinsByIssuerViewModel : INotifyPropertyChanged
    {
        Models.Issuer Issuer { set; }
        IList<Models.Coin> Coins { get; }
    }
}
