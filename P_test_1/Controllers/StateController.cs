using Microsoft.AspNetCore.Mvc;

namespace P_test_1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetState()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 21);
            return Content("Success save to session");
        }
        public IActionResult GetState()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name = {name}, Age = {age}");
        }

        public IActionResult SetCookies()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            HttpContext.Response.Cookies.Append("Age", "10", options);
            return Content("Cookie save");
        }
        public IActionResult GetCookies()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"Name = {name}, Age = {age}");
        }
    }
}
