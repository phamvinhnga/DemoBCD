using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Demo.Service.Base
{
    public static class AutoMapExtension
    {
        public static TOutput JsonMapTo<TOutput>(this object input)
        {
            var value = ConvertToJson(input);
            return value.ConvertFromJson<TOutput>();
        }

        public static string ConvertToJson<TEntitty>(this TEntitty input)
        {
            return JsonConvert.SerializeObject(input, Formatting.None,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                     ContractResolver = new CamelCasePropertyNamesContractResolver()
                 }
             );
        }

        public static TEntity ConvertFromJson<TEntity>(this string input)
        {
            try
            {
                var entity = JsonConvert.DeserializeObject<TEntity>(input);
                return entity;
            }
            catch
            {
            }
            return default(TEntity);
        }
    }
}
