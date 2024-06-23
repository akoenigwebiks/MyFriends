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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            FriendModel friend = Data.Get.Friends.Find(id);
            // Data.Get.Friends.FirstOrDefault(x => x.Id == id);
            return View(friend);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(FriendModel friend)
        //{
        //    if (friend.Id == null) return RedirectToAction("Index");

        //    // Retrieve the existing entity from the context
        //    var targetFriend = Data.Get.Friends.FirstOrDefault(f => f.Id == friend.Id);



        //    if (targetFriend != null)
        //    {
        //        // Update properties of the retrieved entity
        //        targetFriend.FirstName = friend.FirstName;
        //        targetFriend.LastName = friend.LastName;
        //        targetFriend.EmailAddress = friend.EmailAddress;
        //        targetFriend.Phone = friend.Phone;
        //        targetFriend.SetImage = friend.SetImage;
        //        // Add more properties as necessary

        //        // Save changes in the context
        //        Data.Get.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FriendModel friend)
        {
            if (friend.Id == null) return RedirectToAction("Index");

            // Retrieve the existing entity from the context
            var targetFriend = Data.Get.Friends.FirstOrDefault(f => f.Id == friend.Id);

            if (targetFriend == null)
            {
                // Entity not found, so send back to the form with an error message
                ModelState.AddModelError("", "Friend not found. Please check your data and try again.");
                return View(friend);  // Return the model back to the view to display error and let user modify data
            }

            // Update properties of the retrieved entity
            Data.Get.Entry(friend).CurrentValues.SetValues(targetFriend);
            Data.Get.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            FriendModel friend = Data.Get.Friends.Find(id);
            // Data.Get.Friends.FirstOrDefault(x => x.Id == id);
            return View(friend);
        }

        public IActionResult Create()
        {
            return View(new FriendModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(FriendModel friend)
        {
            Data.Get.Friends.Add(friend);
            Data.Get.SaveChanges();
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
