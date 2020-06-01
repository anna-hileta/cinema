using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkerService workerService;
        private readonly UserManager<Worker> userManager;

        public HomeController(IWorkerService workerService, UserManager<Worker> userManager)
        {
            this.workerService = workerService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            var currentUserId = userManager.GetUserId(User);
            var worker =  workerService.GetByIdQueryable(Guid.Parse(currentUserId)).Include(m => m.Position).First();
            return View(new EditWorkerViewModel() {worker = worker });
        }
        [Authorize]
        public IActionResult Instruction()
        {
            return View();
        }
    }
}
