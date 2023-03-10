using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.ViewModels
{
    public interface IIssuersViewModel : INotifyPropertyChanged
    {
        IList<Models.Issuer> Issuers { get; }

        Task ReloadAsync();
    }
}
