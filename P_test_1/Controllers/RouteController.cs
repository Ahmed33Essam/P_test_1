using Microsoft.AspNetCore.Mvc;

namespace P_test_1.Controllers
{
    public class RouteController : Controller
    {
        [Route("M1/{age:int}/{name?}", Name ="Route")]
        public IActionResult Method1(string name, int age)
        {
            return Content($"I am Method1 {name} {age}");
        }

        public IActionResult Method2()
        {
            return Content("I am Method2");
        }   
    }
}
