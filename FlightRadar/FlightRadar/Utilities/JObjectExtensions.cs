using Newtonsoft.Json.Linq;

namespace FlightRadar.Utilities
{
    public static class JObjectExtensions
    {
        public static T GetValue<T>(this JObject json, params string[] paths)
        {
            for (var i = 0; json != null && i < paths.Length - 1; i++)
            {
                if (json.ContainsKey(paths[i]) && json[paths[i]] is JObject)
                {
                    json = json[paths[i]] as JObject;
                }
                else
                {
                    json = null;
                }
            }
            if (json != null
                && json.ContainsKey(paths[paths.Length - 1]))
            {
                return (json[paths[paths.Length - 1]] as JValue).Value<T>();
            }
            else
            {
                return default(T);
            }
        }
    }
}
