using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exception;

namespace ParkingLotApi.Filters
{
    public class InvalidCapacityExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvaildCapacityException invalidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            if (context.Exception is AlreadyExistParkingLotExpection alreadyExistParkingLotExpection)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            if (context.Exception is IdNotExistException idNotExistException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
