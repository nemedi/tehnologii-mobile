using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCatalog.ViewModels
{
    public class CustomerViewModel : ObservableObject
    {
        Models.Customer customer = new Models.Customer();
        
        public string FirstName
        {
            get => customer.FirsName;

            set
            {
                var firstName = customer.FirstName;
                SetProperty<string>(ref firstName, value);
            }
        }

        public string LastName
        {
            get => customer.LastName;
            set => customer.LastName = value;
        }

    }
}
