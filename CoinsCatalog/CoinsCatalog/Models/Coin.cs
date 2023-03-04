using SQLite;

namespace CoinsCatalog.Models
{
    public class Coin
    {
        [PrimaryKey]
        public long Id { get; set; }
        public string Description { get; set; }
        public string Grade { get; set; }
        public string Issuer { get; set; }
        public string Issue { get; set; }
    }
}
