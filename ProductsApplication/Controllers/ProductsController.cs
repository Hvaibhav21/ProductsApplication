using Microsoft.AspNetCore.Mvc;
using ProductsApplication.Models;

namespace ProductsApplication.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>
            {
                 new Product(1,"Nivia",3),
                 new Product(2,"Sunsilk",2)

            };
        

        public IActionResult Index()
        {
            ViewData["Title"] = "Vaibhav View";
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
        public IActionResult Name(NameModel nameData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["Name"] = nameData.Name;
                    ViewData["times"] = nameData.Times;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return View(nameData);
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
