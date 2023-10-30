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
            ViewData["Message"]=TempData["Message"];
            return View(products);
        }
        public IActionResult EditProduct(int id=2)
        {
            TempData["Action"] = "Edit";
            TempData["id"] = id;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int[] id)
        {
            try
            {
                foreach(var Id in id)
                {
                    var product = _productContext.Products.FirstOrDefault(p => p.Id == Id);
                    _productContext.Remove(product);
                }
                
                _productContext.SaveChanges();

                //var entry = _productContext.Entry(id);
                //if (entry.State == EntityState.Deleted)
                //{
                //    TempData["Message"] = "Deleted the Product with id: " + id;
                //}
                TempData["id"] = id;
                TempData["Action"] = "Delete";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> EditProduct([Bind("Id,Title,ReleaseDate,genre,Price")]  Products products)
        {
                if (ModelState.IsValid)
                {
                    //if (id != products.Id) { NotFound(); }
                    var product = _productContext.Products.Update(products);
                    if (product.State == EntityState.Modified)
                    {
                        await _productContext.SaveChangesAsync();
                    TempData["Message"] = "Data is updated";
                    }
                }
                else
                {
                    TempData["Message"] = "Data is not updated";
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
        
        public IActionResult getDetails(int? id)
        {
            TempData["Action"] = "Details";
            TempData["Id"] = id;
            return RedirectToAction("Index");
        }
    }
}
