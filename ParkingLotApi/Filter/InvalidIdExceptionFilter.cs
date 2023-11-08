using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Services.Exceptions;

namespace ParkingLotApi.Filter
{
    public class InvalidIdExceptionFilter : IActionFilter

    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is InvalidIdException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
