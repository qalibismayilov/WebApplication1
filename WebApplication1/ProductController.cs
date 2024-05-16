using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class ProductController : Controller
{
    private static List<Product> products = new List<Product>();

    public IActionResult GetAll()
    {
        return View(products);
    }

    public IActionResult GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        return View(product);
    }

    public IActionResult GetByPrice(decimal price)
    {
        var filteredProducts = products.Where(p => p.Price == price).ToList();
        return View(filteredProducts);
    }

    public IActionResult Add()
    {
        return View(new Product());
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        products.Add(product);
        return RedirectToAction("GetAll");
    }

    public IActionResult Remove(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }
        return RedirectToAction("GetAll");
    }
}
