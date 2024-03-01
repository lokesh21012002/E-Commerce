using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _iwebHost;


        public ProductController(ILogger<ProductController> logger, IProductRepository db, ICategoryRepository db2, IWebHostEnvironment iwebHost, ApplicationDbContext db3)


        {
            _db = db3;
            _iwebHost = iwebHost;

            _logger = logger;
            _productRepository = db;
            _categoryRepository = db2;

        }
        [HttpGet("/Product/Index")]

        public IActionResult Index()
        {

            // List<Category> categories = _db.Categories.ToList();
            List<Product> products = _productRepository.GetALL().ToList();
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });



            return View(products);
        }

        [HttpGet("/Product/Add")]

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });
            ProductView productView = new()
            {
                CategoryList = categoryList,
                Product = new Product()


            };

            ViewBag.CategoryList = categoryList;
            return View(productView);

        }

        [HttpPost("/Product/Add")]
        public IActionResult Add(ProductView obj, IFormFile? formFile)
        {
            // obj.Product.ImageUrl = "";
            Console.WriteLine(obj.Product.CategoryId);






            Console.WriteLine(ModelState.IsValid);
            // if (obj.DisplayOrder.ToString() == obj.Name)
            // {
            //     ModelState.AddModelError("name", "Name and Display order cannnot be same");



            // }
            if (ModelState.IsValid)
            {
                string wwpath = _iwebHost.WebRootPath;

                if (formFile != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    Console.WriteLine(filename);
                    string productPath = Path.Combine(wwpath, @"images/product");
                    Console.WriteLine(productPath);

                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);



                    }
                    obj.Product.ImageUrl = @"/images/product/" + filename;
                    Console.WriteLine(obj.Product.ImageUrl);


                }
                // _db.Categories.Add(obj);
                _productRepository.Add(obj.Product);
                // _db.SaveChanges();
                _productRepository.Save();

                TempData["msg"] = "Product Added successfully";
                return RedirectToAction("Index", "Product");

            }
            else
            {
                IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString(),



                });


                obj.CategoryList = categoryList;

                return View(obj);

            }




            // return View("Add");

        }
        [HttpGet("/Product/Delete/{itemid}"), ActionName("Delete")]
        public ActionResult DeleteConfirm(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Product product = _productRepository.Get(c => c.Id == itemid);

            if (product == null)
            {
                return NotFound();

            }


            return View(product);


        }
        [HttpPost("/Product/Delete/{itemid}")]
        public ActionResult Delete(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Product product = _productRepository.Get(c => c.Id == itemid);

            if (product == null)
            {
                return NotFound();

            }

            // _db.Categories.Remove(category);
            _productRepository.Remove(product);
            // _db.SaveChanges();
            _productRepository.Save();

            TempData["msg"] = "Category Deleted successfully";

            return RedirectToAction("Index", "Product");

        }
        [HttpGet("/Product/Edit/{itemid}")]
        public ActionResult Edit(int itemid, Product objupdated)
        {
            Console.WriteLine(itemid);

            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            // Product product = _productRepository.Get(c => c.Id == itemid);
            Product product = _db.Products.FirstOrDefault(u => u.Id == itemid);

            // Console.WriteLine(product.Id.ToString());
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(product))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(product);
                Console.WriteLine("{0}={1}", name, value);
            }
            if (product == null)
            {
                return NotFound();

            }
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });


            ProductView model = new ProductView()
            {
                Product = product,
                CategoryList = categoryList
            };

            Console.WriteLine(model.Product.ImageUrl);



            return View(model);


            // category.DisplayOrder = objupdated.DisplayOrder;
            // category.Name = objupdated.Name;



            // // _db.Categories.Remove(category);
            // _db.SaveChanges();

            // return RedirectToAction("Index", "Category");

        }
        [HttpPost("/Product/Edit/{itemid}")]
        public ActionResult Edit(Product updatedItem)
        {

            // _db.Categories.Update(updatedItem);
            _productRepository.Update(updatedItem);

            // _db.SaveChanges();
            _productRepository.Save();

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