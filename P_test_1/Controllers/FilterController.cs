using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P_test_1.Controllers
{
    //[Authorize]
    public class FilterController : Controller
    {
        [HandelError]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            throw new Exception("Exception from Index");
        }

        public IActionResult Index2()
        {
            throw new Exception("Exception from Index2");
        }
    }
}
