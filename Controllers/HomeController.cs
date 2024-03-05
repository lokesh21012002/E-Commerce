using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepository _productRepository;

    public HomeController(IProductRepository productRepository)
    {

        _productRepository = productRepository;

    }

    public IActionResult Index()
    {

        IEnumerable<Product> products = _productRepository.GetALL(inlcudeProperties: "Category");

        return View(products);
    }
    public IActionResult Detail(int id)
    {

        Product product = _productRepository.Get(u => u.Id == id, inlcudeProperties: "Category");


        return View(product);
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
