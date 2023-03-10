namespace Names.Data
{
    public interface IRepository
    {
        Task<IList<Models.Result>> GetResultsByName(string name);

        Task SaveResults(IList<Models.Result> items);
    }
}
