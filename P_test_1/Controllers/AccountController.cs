using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P_test_1.Models;
using System.Security.Claims;

namespace P_test_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel userModel)
        {
            if(ModelState.IsValid)
            {
                //Mapping
                ApplicationUser user = new ApplicationUser();
                user.Address = userModel.Address;
                user.UserName = userModel.Name;
                user.PasswordHash = userModel.Password;
                //Save in DB
                IdentityResult result = await userManager.CreateAsync(user, userModel.Password);
                if(result.Succeeded)
                {
                    //assign to role
                    await userManager.AddToRoleAsync(user, "Admin");
                    //cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Department");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description); 
                }
            }
            return View("Register", userModel);
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]//requets.form['_requetss]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid == true)
            {
                //check found 
                ApplicationUser appUser = await userManager.FindByNameAsync(userViewModel.Name);

                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);
                    if (found == true)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appUser.Address));

                        await signInManager.SignInWithClaimsAsync(appUser, userViewModel.RememberMe, claims);
                        //await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }

                }
                ModelState.AddModelError("", "Username OR PAssword wrong");
                //create cookie
            }
            return View("Login", userViewModel);
        }



    }
}
