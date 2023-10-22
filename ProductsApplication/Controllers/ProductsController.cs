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

            ViewData["Title"] = "Vaibhav View";
            return View(products);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            try
            {
                var product = _productContext.Add(products);
                await _productContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct(string name="vaibhav")
        {
            return View();
        }
        public IActionResult Products()
        {
           
               
            return View(products);
        }
        
        public IActionResult Name(int times=1, string name="Vaibhav")
        {
            
            ViewData["Name"] = name;
            ViewData["times"] = times;
            return View();
        }

        [HttpPost]
        public IActionResult Name(Products products)
        {
            var product = _productContext.AddAsync(products);
            return View(product);

        }

        public IActionResult setProduct(int id, string name, int validity)
        {
            ViewData["Title"] = "Vaibhav View";
            var newProduct = new Product(id, name, validity);

            products.Add(newProduct);
           //return "Hello " + id;
            return View(products);
        }
    }
}
