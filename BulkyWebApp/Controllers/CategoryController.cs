
using Bulky.Models.Models;
using BulkyWebApp.DataAcess.Data;

using Microsoft.AspNetCore.Mvc;

namespace BulkyWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> categoryList = _db.Categories.ToList();
        return View(categoryList);
    }



    [HttpPost]
    public IActionResult Create(Category obj) {

        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["sucess"] = "Category Created sucessfull";
            return RedirectToAction("Index");
        }
        return View();
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {

        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["sucess"] = "Category Edited sucessfully";
            return RedirectToAction("Index");
        }
        return View();
    }


    public IActionResult Edit(int id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        Category? catID = _db.Categories.Find(id);
        if (catID == null)
        {
            return NotFound();
        }

        return View(catID);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        Category? catID = _db.Categories.Find(id);
        if (catID == null)
        {
            return NotFound();
        }
           
        _db.Categories.Remove(catID);
        _db.SaveChanges();
        TempData["sucess"] = "Category deleted sucessfull";
        return RedirectToAction("Index");

          }


    public IActionResult Delete(int id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        Category? catID = _db.Categories.Find(id);
        if (catID == null)
        {
            return NotFound();
        }

        return View(catID);
    }
}
