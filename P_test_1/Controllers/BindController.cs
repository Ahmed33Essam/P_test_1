using Microsoft.AspNetCore.Mvc;
using P_test_1.Models;

namespace P_test_1.Controllers
{
    public class BindController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestPrmitive(int id,string name, int age, string[] color)
        {
            return Content($"Name: {name}, Age: {age}");

        }

        public IActionResult tdic(Dictionary<string, string> phone)
        {
            return Content("Ok");
        }

        public IActionResult tobj(Department department)
        {
            return Content("obj");
        }
    }
}
