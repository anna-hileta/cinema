using Cinema.Core.Abstractions.Services;
using Cinema.Core.DAL;
using Cinema.Core.Entities;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class FoodCourtController : Controller
    {
        private readonly ICinemaLocationService cinemaLocationService;
        private readonly IFoodcourtCheckService foodcourtCheckService;
        private readonly IFoodcourtCheckProductService foodcourtCheckProductService;
        private readonly IFoodAmountService foodAmountService;
        private readonly IPDFService pdfService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public FoodCourtController(ICinemaLocationService cinemaLocationService, IPDFService pdfService, IFoodAmountService foodAmountService,
            IFoodcourtCheckService foodcourtCheckService, IFoodcourtCheckProductService foodcourtCheckProductService, 
            UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.cinemaLocationService = cinemaLocationService;
            this.foodcourtCheckService = foodcourtCheckService;
            this.pdfService = pdfService;
            this.foodAmountService = foodAmountService;
            this.foodcourtCheckProductService = foodcourtCheckProductService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var cinemaLocations = cinemaLocationService.GetWithCitiesAndFood();
            List<string> citiesAndLocationStrings = new List<string>();
            foreach(var a in cinemaLocations)
            {
                var temp = a.CinemaName + ", " + a.City.CityName;
                citiesAndLocationStrings.Add(temp);
            }
            return View(new FoodViewModel() { locations = cinemaLocations, allCinemas = citiesAndLocationStrings });
        }
        [HttpPost]
        public int BuyFood([FromBody] FoodDTO food)
        {
            try
            {
                var currentUserId = userManager.GetUserId(User);
                var checkId = foodcourtCheckService.Add(new FoodcourtCheck()
                {
                    PaidPrice = (decimal) food.Price,
                    TransactionDateAndTime = DateTime.Now,
                    WorkerId = Guid.Parse(currentUserId)
                });
                for (int i = 0; i < food.TicketIds.Count; ++i)
                {
                    foodcourtCheckProductService.Add(new FoodcourtCheckProduct()
                    {
                        FoodcourtCheckId = checkId.Id,
                        FoodAmountId = food.TicketIds[i].Id,
                        AmountOfProduct = food.TicketIds[i].Amount
                    });
                    var oldFoodAmount = foodAmountService.GetById(food.TicketIds[i].Id);
                    oldFoodAmount.ProductAmount -= food.TicketIds[i].Amount;
                    foodAmountService.Update(oldFoodAmount);
                }

                return checkId.Id;
            }
            catch
            {
                return 0;
            }
        }
        [HttpGet]
        [Route("/Foodcourt/CreatePDFCheck/{objId}")]
        public async Task<IActionResult> CreatePDFAsync(int objId)
        {
            if (objId <= 0)
            {
                throw new ArgumentException("Cannot crated pdf id is not valid");
            }
            var check = foodcourtCheckService.GetWithAllInfo(objId);
            byte[] arr = await pdfService.DecesionCreatePDFAsyncForFood(check);
            return File(arr, "application/pdf");
        }

    }
}