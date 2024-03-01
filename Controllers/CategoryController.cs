using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
using MVC.Repository;
using MVC.Services;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        // private readonly ApplicationDbContext _db;

        private readonly ICategoryRepository _categoryRepository;
        // private readonly IScopedService _scoped1;
        // private readonly IScopedService _scoped2;

        // private readonly ISingeltonService _singelton1;
        // private readonly ISingeltonService _singelton2;
        // private readonly ItransistService _transist1;
        // private readonly ItransistService _transist2;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository db)
        {
            _categoryRepository = db;
            _logger = logger;
            // _singelton1 = singelton1;
            // _singelton2 = singelton2;
            // _scoped1 = scoped1;
            // _scoped2 = scoped2;
            // _transist1 = transist1;
            // _transist2 = transist2;



        }
        [HttpGet("/Category/Index")]

        public IActionResult Index()
        {

            // List<Category> categories = _db.Categories.ToList();
            List<Category> categories = _categoryRepository.GetALL("").ToList();


            return View(categories);
        }

        [HttpGet("/Category/Add")]

        public IActionResult Add()
        {
            return View("Add");

        }

        [HttpPost("/Category/Add")]
        public IActionResult Add(Category obj)
        {

            if (obj.DisplayOrder.ToString() == obj.Name)
            {
                ModelState.AddModelError("name", "Name and Display order cannnot be same");



            }
            if (ModelState.IsValid)
            {
                // _db.Categories.Add(obj);
                _categoryRepository.Add(obj);
                // _db.SaveChanges();
                _categoryRepository.Save();

                TempData["msg"] = "Category Added successfully";
                return RedirectToAction("Index", "Category");

            }

            return View();


            // return View("Add");

        }
        [HttpGet("/Category/Delete/{itemid}"), ActionName("Delete")]
        public ActionResult DeleteConfirm(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Category category = _categoryRepository.Get(c => c.ID == itemid, "");

            if (category == null)
            {
                return NotFound();

            }


            return View(category);


        }
        [HttpPost("/Category/Delete/{itemid}")]
        public ActionResult Delete(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Category category = _categoryRepository.Get(c => c.ID == itemid, "");

            if (category == null)
            {
                return NotFound();

            }

            // _db.Categories.Remove(category);
            _categoryRepository.Remove(category);
            // _db.SaveChanges();
            _categoryRepository.Save();

            TempData["msg"] = "Category Deleted successfully";

            return RedirectToAction("Index", "Category");

        }
        [HttpGet("/Category/Edit/{itemid}")]
        public ActionResult Edit(int itemid, Category objupdated)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Category category = _categoryRepository.Get(c => c.ID == itemid, "");
            if (category == null)
            {
                return NotFound();

            }


            return View(category);


            // category.DisplayOrder = objupdated.DisplayOrder;
            // category.Name = objupdated.Name;



            // // _db.Categories.Remove(category);
            // _db.SaveChanges();

            // return RedirectToAction("Index", "Category");

        }
        [HttpPost("/Category/Edit/{itemid}")]
        public ActionResult Edit(Category updatedItem)
        {

            // _db.Categories.Update(updatedItem);
            _categoryRepository.Update(updatedItem);

            // _db.SaveChanges();
            _categoryRepository.Save();

            TempData["msg"] = "Category Edited successfully";
            return RedirectToAction("Index", "Category");


        }





        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}