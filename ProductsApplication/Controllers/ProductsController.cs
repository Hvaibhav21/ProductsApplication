using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProductsApplication.Data;
using ProductsApplication.Models;

namespace ProductsApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsApplicationContext _productContext;
        public ProductsController(ProductsApplicationContext productsApplicationContext)
        {
            _productContext = productsApplicationContext;
        }
        List<Product> products = new List<Product>
            {
                 new Product(1,"Nivia",3),
                 new Product(2,"Sunsilk",2)

            };
        public async Task<IActionResult> Index()
        {
            var products = await _productContext.Products.ToListAsync();
            ViewData["Action"] = TempData["Action"];
            ViewData["Id"] = TempData["id"];
            ViewData["Title"] = "Vaibhav View";
            return View(products);
        }
        public async Task<IActionResult> EditProduct(int id=2)
        {
            TempData["Action"] = "Edit";
            TempData["id"] = id;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, Products products)
        {
            if (ModelState.IsValid)
            {
                if (id != products.Id) { NotFound(); }
                _productContext.Products.Update(products);
                await _productContext.SaveChangesAsync();
            }
            //var product = _productContext.Products.FindAsync(id);
            //TempData["product"] = product;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            try
            {
                var product = _productContext.Add(products);
                await _productContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct(string name = "vaibhav")
        {
            return View();
        }


      
    }
}
