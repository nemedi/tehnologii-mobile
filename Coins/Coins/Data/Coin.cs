using SQLite;

namespace Coins.Data
{
    public class Coin
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }

        [Ignore]
        public bool New { get; set; } = true; 
    }
}
