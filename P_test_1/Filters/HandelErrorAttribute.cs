using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P_test_1.Filters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult content = new ContentResult();
            //content.Content = "Some Exception throw";
            ViewResult view = new ViewResult();
            view.ViewName = "Error";
            context.Result = view;
        }
    }
}
