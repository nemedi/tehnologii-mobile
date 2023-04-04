using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Essentials.ViewModels
{
	public class ObservableObject : INotifyPropertyChanged
	{
		protected virtual bool SetProperty<T>(ref T store, T value, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(store, value))
			{
                return false;
			}
			else
			{
                store = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
