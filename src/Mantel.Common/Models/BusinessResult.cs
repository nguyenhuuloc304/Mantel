using Mantel.Common.Enums;
using Mantel.Common.Extensions;
using Mantel.Common.Http.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Models
{
    public class BusinessResult<T>
    {
        public BusinessResult()
        {
        }

        public BusinessResult(T data)
        {
            Status = ReturnStatus.OK;
            Data = data;
        }

        public BusinessResult(ReturnStatus status, string responseCode = null, List<string> parameters = null)
        {
            Status = status;
            Message = CreateMessage(status, responseCode, parameters);
        }

        public BusinessResult(WebApiErrorDetails error)
        {
            Status = error.StatusCode.ToReturnStatus();
            Message = error.ApiError?.Message;
        }

        public ReturnStatus Status { get; set; }

        public T Data { get; set; }

        public string BusinessResponseCode { get; set; } = "";

        public string Message { get; set; } = "";

        public List<string> Parameters { get; set; } = null;

        public bool IsTranslated { get; set; } = false;

        private string CreateMessage(ReturnStatus status, string responseCode, List<string> parameters = null)
        {
            if (!string.IsNullOrEmpty(responseCode))
            {
                // Error message to display
                return responseCode;
            }

            return Status switch
            {
                ReturnStatus.Error => "Error",
                ReturnStatus.NotFound => "NotFound",
                ReturnStatus.BadRequest => "BadRequest",
                ReturnStatus.Unauthorized => "Unauthorized",
                ReturnStatus.Forbidden => "Forbidden",
                ReturnStatus.MethodNotAllowed => "MethodNotAllowed",
                _ => ""
            };
        }
    }
}
