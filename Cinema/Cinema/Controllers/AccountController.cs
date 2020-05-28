using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IWorkerService workerService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public AccountController(IPositionService positionService, IWorkerService workerService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.workerService = workerService;
            this.positionService = positionService;
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
            var p = positionService.Get();
            return View(new PositionsViewModel() {positions =  p});
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string Name, string Surname, string Fathername, string PassportData, int typeSelect, [FromQuery] string ReturnUrl)
        {
            var position = positionService.GetById(typeSelect);
            var worker = new Worker()
            {
                UserName = username,
                Name = Name,
                Surname = Surname,
                FatherName = Fathername,
                PassportData = PassportData,
                Position = position
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

            return RedirectToAction("WorkerTable", "AdminTables");
        }

        public IActionResult EditProfile(string id)
        {
            var worker = workerService.GetById(Guid.Parse(id));
            var p = positionService.Get();
            return View(new EditWorkerViewModel() { worker = worker, positions = p });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string oldId, string Name, string Surname, string Fathername, string PassportData, int typeSelect, [FromQuery] string ReturnUrl)
        {
            var position = positionService.GetById(typeSelect);
            var workerOld = workerService.GetById(Guid.Parse(oldId));
            workerOld.Name = Name;
            workerOld.FatherName = Fathername;
            workerOld.Surname = Surname;
            workerOld.PassportData = PassportData;
            workerOld.Position = position;
            workerOld.PositionId = position.Id;
            workerService.Update(workerOld);


            return RedirectToAction("WorkerTable", "AdminTables");
        }
        public IActionResult EditProfileLimited(string id)
        {
            var worker = workerService.GetById(Guid.Parse(id));
            return View(new EditWorkerViewModel() { worker = worker });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfileLimited(string oldId, string Name, string Surname, string Fathername, string PassportData, [FromQuery] string ReturnUrl)
        {
            var workerOld = workerService.GetById(Guid.Parse(oldId));
            workerOld.Name = Name;
            workerOld.FatherName = Fathername;
            workerOld.Surname = Surname;
            workerOld.PassportData = PassportData;
            workerService.Update(workerOld);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }


}