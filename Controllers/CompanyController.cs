using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ILogger<Company> _logger;
        private readonly ICompanyRepository _companyRepository;
        private readonly IWebHostEnvironment _iwebHost;

        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _db;

        public CompanyController(ILogger<Company> logger, ICompanyRepository companyRepository, ICategoryRepository categoryRepository, IWebHostEnvironment iwebHost, ApplicationDbContext db)
        {
            _iwebHost = iwebHost;
            _db = db;

            _logger = logger;
            _companyRepository = companyRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("/Company/Index")]

        public IActionResult Index()
        {

            // List<Category> categories = _db.Categories.ToList();
            List<Company> Companys = _companyRepository.GetALL(inlcudeProperties: "Category").ToList();
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL("").Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });



            return View(Companys);
        }

        [HttpGet("/Company/Add")]

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL("").Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });
            ProductView ProductView = new()
            {
                CategoryList = categoryList,
                Product = new Product()


            };

            ViewBag.CategoryList = categoryList;
            return View(ProductView);

        }

        [HttpPost("/Company/Add")]
        public IActionResult Add(ProductView obj, IFormFile? formFile)
        {
            // obj.Company.ImageUrl = "";
            // Console.WriteLine(obj.Company.CategoryId);






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
                    string CompanyPath = Path.Combine(wwpath, @"images/Company");
                    Console.WriteLine(CompanyPath);

                    using (var fileStream = new FileStream(Path.Combine(CompanyPath, filename), FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);



                    }
                    obj.Company.ImageUrl = @"/images/Company/" + filename;
                    Console.WriteLine(obj.Company.ImageUrl);


                }
                // _db.Categories.Add(obj);
                _companyRepository.Add(obj.Company);
                // _db.SaveChanges();
                _companyRepository.Save();

                TempData["msg"] = "Company Added successfully";
                return RedirectToAction("Index", "Company");

            }
            else
            {
                IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL("").Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString(),



                });


                obj.CategoryList = categoryList;

                return View(obj);

            }




            // return View("Add");

        }
        [HttpGet("/Company/Delete/{itemid}"), ActionName("Delete")]
        public ActionResult DeleteConfirm(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Company Company = _companyRepository.Get(c => c.Id == itemid, "");

            if (Company == null)
            {
                return NotFound();

            }


            return View(Company);


        }
        [HttpPost("/Company/Delete/{itemid}")]
        public ActionResult Delete(int itemid)
        {
            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            Company Company = _companyRepository.Get(c => c.Id == itemid, "");

            if (Company == null)
            {
                return NotFound();

            }

            // _db.Categories.Remove(category);
            _companyRepository.Remove(Company);
            // _db.SaveChanges();
            _companyRepository.Save();

            TempData["msg"] = "Category Deleted successfully";

            return RedirectToAction("Index", "Company");

        }
        [HttpGet("/Company/Edit/{itemid}")]
        public ActionResult Edit(int itemid, Company objupdated)
        {
            Console.WriteLine(itemid);

            // Category category = _db.Categories.FirstOrDefault(c => c.ID == itemid);
            // Company Company = _companyRepository.Get(c => c.Id == itemid);
            Company Company = _db.Companies.FirstOrDefault(u => u.Id == itemid);

            // Console.WriteLine(Company.Id.ToString());
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(Company))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(Company);
                Console.WriteLine("{0}={1}", name, value);
            }
            if (Company == null)
            {
                return NotFound();

            }
            IEnumerable<SelectListItem> categoryList = _categoryRepository.GetALL("").Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString(),



            });


            CompanyView model = new CompanyView()
            {
                Company = Company,
                CategoryList = categoryList
            };

            Console.WriteLine(model.Company.ImageUrl);



            return View(model);


            // category.DisplayOrder = objupdated.DisplayOrder;
            // category.Name = objupdated.Name;



            // // _db.Categories.Remove(category);
            // _db.SaveChanges();

            // return RedirectToAction("Index", "Category");

        }
        [HttpPost("/Company/Edit/{itemid}")]
        public ActionResult Edit(Company updatedItem)
        {

            // _db.Categories.Update(updatedItem);
            _companyRepository.Update(updatedItem);

            // _db.SaveChanges();
            _companyRepository.Save();

            TempData["msg"] = "Category Edited successfully";
            return RedirectToAction("Index", "Category");


        }



    }
}