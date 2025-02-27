using Microsoft.AspNetCore.Mvc.Filters;

namespace P_test_1.Filters
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
