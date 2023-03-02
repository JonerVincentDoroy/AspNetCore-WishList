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
        public IActionResult Index()
        {
            //display a list of item wishlist
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //call create view after clicking Add Item button
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            //after creating an item redirect back to index view
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int id) 
        {
            //check if there is an item with matching id
            var itemToRemove = _context.Items.FirstOrDefault(item => item.Id == id);
            
            _context.Items.Remove(itemToRemove);
            
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
