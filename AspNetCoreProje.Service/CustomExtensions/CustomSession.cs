using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspNetCoreProje.Service.CustomExtensions
{
    public static class CustomSession
    {
        public static void SetObject<T>(this ISession session, string key, T value) where T:class, new()
        {
           var stringData = JsonConvert.SerializeObject(value);
            session.SetString(key, stringData);
        }
        public static T GetObject<T>(this ISession session, string key) where T:class, new()
        {
            var jsonData = session.GetString(key);

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
               return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }
    }
}
