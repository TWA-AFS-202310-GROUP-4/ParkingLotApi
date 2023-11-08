using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Services.Exceptions;

namespace ParkingLotApi.Filter
{
    public class InvalidCapacityExceptionFilter : IActionFilter

    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is InvalidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
