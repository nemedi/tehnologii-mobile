using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoinsCatalog.ViewModels
{
    public class ObservableObject : INotifyPropertyChanged
    {
        protected void SetProperty<T>(ref T store, T value, [CallerMemberName] string name = "")
        {
            store = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
