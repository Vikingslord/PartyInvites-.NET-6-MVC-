using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using PartyInvites.Models.Repository;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //int hour = DateTime.Now.Hour;
            //ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            int hour = DateTime.Now.Hour;
            ViewData["Greeting"] = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse) 
        {
            if (ModelState.IsValid)
            {
                //To store response from user
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}