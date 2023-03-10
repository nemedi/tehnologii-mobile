using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Names.Services
{
    public class DataService : IDataService
    {
        private Data.IRepository repository;

        public DataService(Data.IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IList<Models.Result>> GetResultsByName(string name)
        {
            var results = await repository.GetResultsByName(name);
            if (results.Count == 0)
            {
                results = await SearchName(name);
            }
            return results;
        }

        private async Task<IList<Models.Result>> SearchName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var text = await client.GetStringAsync(
                    Utilities.Constants.NameSearchEndpoint + name.ToLower());
                dynamic nameSearchData = JObject.Parse(text);
                IDictionary<string, int> countByDistrict = new Dictionary<string, int>();
                foreach (var result in nameSearchData.ani)
                {
                    var locationResolveEndpoint = string.Format(Utilities.Constants.LocationResolveEndpoint,
                         result.area.centroid_lat, result.area.centroid_lng);
                    text = await client.GetStringAsync(locationResolveEndpoint);
                    dynamic locationResolveData = JObject.Parse(text);
                    if (locationResolveData?.address?.country == "România"
                        && locationResolveData?.address?.county is not null)
                    {
                        string district = locationResolveData.address.county;
                        if (countByDistrict.ContainsKey(district))
                        {
                            countByDistrict[district] += (int) result.count;
                        } else
                        {
                            countByDistrict[district] = (int) result.count;
                        }
                    }
                }
                var results = new List<Models.Result>();
                foreach (var key in countByDistrict.Keys)
                {
                    results.Add(new Models.Result
                    {
                        Name = name,
                        District = key,
                        Count = countByDistrict[key]
                    });
                }
                await repository.SaveResults(results);
                results.Sort((first, second) => second.Count - first.Count);
                return results;
            }
        }
    }
}
