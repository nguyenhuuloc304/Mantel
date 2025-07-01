using Mantel.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Extensions
{
    public static class ResultStatusExtension
    {
        public static ReturnStatus ToReturnStatus(this HttpStatusCode httpStatus)
        {
            switch (httpStatus)
            {
                case HttpStatusCode.NoContent:
                    return ReturnStatus.NotFound;
                case HttpStatusCode.InternalServerError:
                    return ReturnStatus.Error;
                case HttpStatusCode.BadRequest:
                    return ReturnStatus.BadRequest;
                case HttpStatusCode.Forbidden:
                    return ReturnStatus.Forbidden;
                case HttpStatusCode.Unauthorized:
                    return ReturnStatus.Unauthorized;
                default:
                    return ReturnStatus.OK;
            }
        }

        public static HttpStatusCode ToHttpStatusCode(this ReturnStatus value)
        {
            switch (value)
            {
                case ReturnStatus.NotFound:
                    return HttpStatusCode.NoContent;
                case ReturnStatus.Error:
                    return HttpStatusCode.InternalServerError;
                case ReturnStatus.BadRequest:
                    return HttpStatusCode.BadRequest;
                case ReturnStatus.Forbidden:
                    return HttpStatusCode.Forbidden;
                case ReturnStatus.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                default:
                    return HttpStatusCode.OK;
            }
        }
    }
}
