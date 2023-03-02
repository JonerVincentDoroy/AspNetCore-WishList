using Microsoft.AspNetCore.Mvc;

namespace WishList.Controllers
{
    public class HomeController : Controller
    {
        //call Index page if requested
        public IActionResult Index()
        {
            return View("Index");
        }

        //call Error page if requested
        public IActionResult Error() 
        {
            return View("Error");
        }
    }
}
