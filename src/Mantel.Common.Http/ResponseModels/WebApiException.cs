using Mantel.Common.Http.ResponseModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Mantel.Common.Http
{
    public class WebApiException : Exception
    {
        public WebApiErrorDetails ErrorDetails { get; }

        public WebApiException(string message, WebApiErrorDetails errorDetails)
            : base(message)
        {
            ErrorDetails = errorDetails;
        }
    }
}
