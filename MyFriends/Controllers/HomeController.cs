using Microsoft.AspNetCore.Mvc;
using MyFriends.Models;
using MyFriends.DAL;
using System.Diagnostics;

namespace MyFriends.Controllers
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
            List<FriendModel> friendsList = Data.Get.Friends.ToList();
            return View(friendsList);
        }

        public IActionResult Create()
        {
            return View(new FriendModel());
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(FriendModel friend)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
