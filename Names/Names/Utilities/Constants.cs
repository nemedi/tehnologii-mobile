using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Names.Utilities
{
    internal class Constants
    {
        public const string DatabaseFile = "Names.db";
        public const string NameSearchEndpoint = "https://nume.ottomotor.ro/get_nume.json?zoom=7&nw_lat=49.55372551347579&nw_lng=20.324707031250004&se_lat=42.220381783720605&se_lng=29.761962890625004&search=";
        public const string LocationResolveEndpoint = "https://nominatim.openstreetmap.org/reverse.php?lat={0}&lon={1}&zoom=18&format=jsonv2&email=inemedi@ie.ase.ro";
    }
}
