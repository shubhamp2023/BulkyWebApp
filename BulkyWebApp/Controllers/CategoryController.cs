using BulkyWebApp.Data;
using BulkyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
           List<Category> categoryList =   _db.Categories.ToList();
            return View(categoryList);
        }



        [HttpPost]
        public IActionResult Create( Category obj) {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            }


        public IActionResult Create()
        {
            return View();
        }
    }
}
