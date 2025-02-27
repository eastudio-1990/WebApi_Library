using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Application.Middleware
{
    public  class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new { message = "Internal Server Error" })
            {
                StatusCode = 501,                
            };
        }
    }
}
