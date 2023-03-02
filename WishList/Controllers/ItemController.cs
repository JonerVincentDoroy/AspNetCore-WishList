using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController (ApplicationDbContext context)
        {
            _context = context;
        }

        //display a list of item wishlist
        public IActionResult Index()
        {
            
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        //call create view after clicking Add Item button
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        //*redirectToAction - after creating an item redirect back to index view
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //FirstOrDefault - check if there is an item with matching id
        public IActionResult Delete (int id) 
        {
            
            var itemToRemove = _context.Items.FirstOrDefault(item => item.Id == id);
            
            _context.Items.Remove(itemToRemove);
            
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
