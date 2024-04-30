using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Rhyous.Reddit
{
    [ExcludeFromCodeCoverage] // This is wrapping static code, no reason to test wrappers.
    class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string json) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
