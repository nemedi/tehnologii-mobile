using SQLite;

namespace Names.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public string District { get; set; }
    }
}
