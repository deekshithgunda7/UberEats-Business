using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GuitarShop.Models;


namespace GuitarShop.Controllers
{
    public class PartnerController : Controller
    {
          private ShopContext context;
         private List<Category> categories;
       

        // private List<Category> categories;

        public PartnerController(ShopContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
            ViewBag.Categories = categories;
            
            // ViewBag.SelectedCategoryName = id;
        }
     
      
          public IActionResult Index()
        {
            return View();
        }

        // [HttpGet]
        // public IActionResult add()
        // {
        //   return View();
        // }
       [Route("[controller]/add")]
       [HttpGet]
        public IActionResult add()
        {
            // List<Product> products;
            // products = context.Products
            //         .OrderBy(p => p.ProductID).ToList();
            Product product = new Product(); 
            ViewBag.Categories = categories;
            return View("add",product);
        }
       
        [HttpPost]
        public IActionResult add(Product product)
        {
           
                context.Products.Add(product);
                context.SaveChanges();
                TempData["Message"] = "Partner Application "+product.BusinessName+"  has been received.We will email you once the application has been recieved";
                return RedirectToAction("","Home");
           
        }

      
    }
}
