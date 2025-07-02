using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Common.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            switch (exception)
            {
                case InvalidDataException invalidDataException:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
                default:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}
