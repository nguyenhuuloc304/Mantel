using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Mantel.Common.Http.ResponseModels
{
    public class WebApiErrorDetails
    {
        protected static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        { NullValueHandling = NullValueHandling.Ignore };

        public WebApiErrorDetails()
        { }

        public WebApiErrorDetails(HttpStatusCode code, ApiError apiError = null)
        {
            StatusCode = code;
            ApiError = apiError;
        }

        public WebApiErrorDetails(HttpStatusCode code, string message) :
            this(code, new ApiError { Message = message })
        {
        }

        public WebApiErrorDetails(Exception ex)
            : this(HttpStatusCode.InternalServerError,
                new ApiError
                {
                    Code = "InternalServerError",
                    Message = ex.Message,
                    Exception = ex
                })
        {
        }

        public void CheckResponse(string currentAction)
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
                throw new WebApiException($"Failed to {currentAction}", this);
        }

        public HttpStatusCode StatusCode { get; set; }
        public Uri RequestPath { get; set; }
        public ApiError ApiError { get; set; }
        public WebApiErrorDetails InnerError { get; set; }

        /// <summary>
        /// For backwards compatibility only
        /// </summary>
        public ApiError Error
        {
            get => null;
            set => ApiError = value ?? ApiError;
        }

        public HttpStatusCode ReturnStatusCode
        {
            get
            {
                switch (StatusCode)
                {
                    // Return select 4xx messages so we know the core reason for failure
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Conflict:
                        return StatusCode;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
        }

        public virtual IActionResult ToActionResult()
        {
            return new ObjectResult(this)
            {
                ContentTypes = { "application/json" },
                StatusCode = (int)ReturnStatusCode,
                //Formatters = { new NewtonsoftJsonOutputFormatter(JsonSerializerSettings, ArrayPool<char>.Shared, new MvcOptions()) }
            };
        }

        public virtual async Task WriteToResponse(HttpResponse response)
        {
            response.StatusCode = (int)ReturnStatusCode;
            response.ContentType = "application/json";

            string responseBody = JsonConvert.SerializeObject(this, JsonSerializerSettings);
            await response.WriteAsync(responseBody);
        }
    }
}
