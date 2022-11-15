using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpongeBob.Models;
using System.Diagnostics;
using System.Dynamic;

namespace SpongeBob.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<SpongeBobFriends> friends = (from m in _context.Friends select m).ToList();
            return View(friends);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateHome()
        {
            return View();
        }
        // crud
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHome([Bind("HomeType")] Home home)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(home);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
            }

            return View(home);
        }
        [HttpGet]
        public async Task<IActionResult> CreateFriend()
        {
            return View();
        }
        // crud
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFriend([Bind("FirstName, LastName, Job, JobPlace, SkinCollor, HomeId")] SpongeBobFriends friend)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(friend);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
            }
            return View(friend);
        }
        public async Task<IActionResult> FriendInformation(string searched)
        {
            //string searched
            var searchPerson = from m in _context.Friends select m; //LINQ 

            if (!String.IsNullOrEmpty(searched))
            {
                searchPerson = searchPerson.Where(s => s.FirstName.Contains(searched));
            }

            return View(await searchPerson.ToListAsync());
        }

        public async Task<IActionResult> PartialFriends()
        {
            return PartialView("PartialFriends");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}