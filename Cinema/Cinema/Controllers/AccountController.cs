using Cinema.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public AccountController(UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, [FromQuery] string ReturnUrl)
        {
            var worker = await userManager.FindByNameAsync(username);

            if (worker != null)
            {
                var result = await signInManager.PasswordSignInAsync(username, password, false, false);

                if (result.Succeeded)
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                }
                else
                {
                    // sign in failure
                }
            }
            else
            {
                // no user found
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, [FromQuery] string ReturnUrl)
        {
            var worker = new Worker()
            {
                UserName = username,
                Name = "TestName",
                Surname = "TestSurname",
                FatherName = "Test"
            };

            var result = await userManager.CreateAsync(worker, password);

            if (result.Succeeded)
            {
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                // sign up failure
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }


}