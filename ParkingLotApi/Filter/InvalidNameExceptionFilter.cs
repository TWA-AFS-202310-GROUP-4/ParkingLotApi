using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filter
{
    public class InvalidNameExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;
        public void OnActionExecuted(ActionExecutedContext context) // when controller method return
        {
            if (context.Exception is InvalidNameException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) // before controller method run
        {
        }
    }
}
