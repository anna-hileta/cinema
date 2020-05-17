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
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IWorkerService workerService;
        private readonly ITicketCheckService ticketcheckService;
        private readonly ICheckService checkService;
        private readonly IPDFService pdfService;
        private readonly ITicketService ticketService;
        private readonly IShowingService showingService;
        private readonly UserManager<Worker> userManager;
        private readonly SignInManager<Worker> signInManager;

        public MovieController( IMovieService movieService, IPDFService pdfService, ITicketService ticketService, IWorkerService workerService, ITicketCheckService ticketcheckService, ICheckService checkService, IShowingService showingService, UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            this.workerService = workerService;
            this.movieService = movieService;
            this.pdfService = pdfService;
            this.ticketcheckService = ticketcheckService;
            this.checkService = checkService;
            this.ticketService = ticketService;
            this.showingService = showingService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var movie = movieService.Get();
            return View(new MovieViewModel() { movies = movie});
        }
        public IActionResult Movie(int index)
        {
            var movies = movieService.GetWithAllInfo();
            var movie = movies.Where(m => m.Id == index)
                 .First();
            return View(new MovieViewModel() { movie = movie });
        }
        public IActionResult MovieShowing(int showingId)
        {
            var movie = showingService.GetShowingInfo(showingId);
            return View(new ShowingViewModel() { showings = movie });
        }
        [HttpPost]
        public int Buy([FromBody] TicketsDTOcs ticket)
        {
            try
            {
                var currentUserId = userManager.GetUserId(User);
                var checkId =new Check()
                {
                    TicketChecks = new List<TicketCheck>(),
                    PaidPrice = (decimal)ticket.money,
                    TransactionDateAndTime = DateTime.Now,
                    WorkerId = Guid.Parse(currentUserId)
                }; 
                for(int i=0; i < ticket.TicketIds.Count; ++i)
                {
                    var tick = ticketService.GetById(ticket.TicketIds[i]);
                    checkId.TicketChecks.Add(
                        new TicketCheck()
                    {
                        TicketId = tick.Id
                    });
                    tick.Status = true;
                    ticketService.Update(tick);
                }
                checkService.Add(checkId);

                return checkId.Id;
            }
            catch
            {
                return 0;
            }
        }
        [HttpGet]
        [Route("/Movie/CreatePDF/{objId}")]
        public async Task<IActionResult> CreatePDFAsync(int objId)
        {
                if (objId <= 0)
                {
                    throw new ArgumentException("Cannot crated pdf id is not valid");
                }
                var check = checkService.GetWithAllInfo(objId);
                byte[] arr = await pdfService.DecesionCreatePDFAsync(check);
                return File(arr, "application/pdf");
        }
    }


}