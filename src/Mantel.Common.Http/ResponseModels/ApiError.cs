using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Mantel.Common.Http
{
    public class ApiError
    {
        public string Code { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public Exception Exception
        {
            set => ExceptionAsString = value?.ToString();
        }

        [JsonProperty("Exception")]
        public string ExceptionAsString { get; set; }
    }
}
